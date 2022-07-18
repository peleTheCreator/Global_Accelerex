using System;
using System.Threading;
using System.Threading.Tasks;
using OpeningHours.Commands;
using OpeningHours.Mapping;
using OpeningHours.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OpeningHours.Reprositories;
using System.Collections.Generic;
using System.Linq;
using OpeningHours.Dtos;
using OpeningHours.Extensions;

namespace OpeningHours.Handlers
{
    public class CreateOpeningHoursCommandHandler : IRequestHandler<CreateOpeningHoursCommand, OpeningHoursResponse>
    {
        private readonly IOpeningHoursRepository _openingHoursRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateOpeningHoursCommandHandler> _logger;

        public CreateOpeningHoursCommandHandler(ILogger<CreateOpeningHoursCommandHandler> logger, IOpeningHoursRepository openingHoursRepository, IMapper mapper)
        {
            _logger = logger;
            _openingHoursRepository = openingHoursRepository;
            _mapper = mapper;
        }

        public async Task<OpeningHoursResponse> Handle(CreateOpeningHoursCommand request, CancellationToken cancellationToken)
        {
            var closed = true;
            object prev_day = null;
            var processed_days = new Dictionary<string, object>();
            int i = 0;


            var days_to_process = new List<string> {
                "monday",
                "tuesday",
                "wednesday",
                "thursday",
                "friday",
                "saturday",
                "sunday",
                "monday",
            };

            var sourceopeningHours = Helper.Helper.ToDictionary<List<OpeningHourData>>(request);

            foreach (var day in days_to_process)
            {
                if (sourceopeningHours.ContainsKey(day))
                {
                    var times = sourceopeningHours[day]?.ToList();

                    if (times != null && times?.Count > 0)
                    {
                        // Close previous day if needed
                        if (times[0].type == "close")
                        {
                            if (prev_day != null && !closed)
                            {
                                var prevday = days_to_process[i - 1];
                                var prevdaytimes = processed_days[prevday];
                                var prevdaytimescollection = (List<object>)prevdaytimes;
                                prevdaytimescollection.Add(times[0].value);
                                processed_days[prevday] = prevdaytimescollection;
                                prev_day = prevdaytimescollection;
                                closed = true;
                            }
                            times = times.Skip(1).ToList();
                        }

                        // Process current day
                        if (!processed_days.ContainsKey(day))
                        {
                            var processed_day = new List<object>();
                            processed_days[day] = processed_day;
                            foreach (var e in times)
                            {
                                if (closed && e.type == "open" || !closed && e.type == "close")
                                {
                                    processed_day.Add(e.value);

                                    closed = !closed;
                                }
                                else
                                {
                                    Console.WriteLine("Wrong input data!");
                                }
                            }
                            prev_day = processed_day;
                        }

                    }
                    else
                    {
                        processed_days[day] = 0;
                    }
                    i++;



                }
            }


            OpeningHourDto formatedopeningHour = FormatedOpenHour(processed_days);
            var openingHours = await _openingHoursRepository.CreateOpeningHoursAsync(formatedopeningHour);
            _logger.LogInformation($"Created opening hour for: {openingHours.Id}");

            return _mapper.MapopeningHoursDtoToOpeningHoursResponse(openingHours);
        }

        private OpeningHourDto FormatedOpenHour(Dictionary<string, object> processed_days)
        {
            OpeningHourDto response = new OpeningHourDto();

            for (int j = 0; j < processed_days.Count; j++)
            {
                var entry = processed_days.ElementAt(j);

                var key = entry.Key.Substring(0, 1).ToUpper() + entry.Key.Substring(1);


                dynamic value = entry.Value;
                var entryvaluelist = new List<object>();

                if (value is List<object>)
                    entryvaluelist = (List<object>)entry.Value;

                if (value is int)
                    response.Opening.Add(key + " :  Closed");
                else
                {
                    var display = string.Empty;
                    int k = 0;
                    var addcommanext = false;
                    foreach (var e in entryvaluelist)
                    {
                        var v = (long)e;

                        if (addcommanext)
                            display = display + " , ";

                        if (k == 0)
                            display = v.ToDateTime().TimeofTheDay().ToUpper();
                        else
                            display = display + " - " + v.ToDateTime().TimeofTheDay().ToUpper();

                        if (k % 2 == 0 && k != 0)
                            addcommanext = true;
                        k++;
                    }
                    response.Opening.Add(key + " : " + display);


                }
            }

            return response;
        }



    }
}