using OpeningHours.Dtos;
using OpeningHours.Responses;
using System.Collections.Generic;

namespace OpeningHours.Mapping
{
    public class Mapper : IMapper
    {
        public OpeningHoursResponse MapopeningHoursDtoToOpeningHoursResponse(OpeningHourDto openingHours)
        {
            return new OpeningHoursResponse
            {
                Id = openingHours.Id,
                Opening = openingHours.Opening,

            };
        }

        public List<OpeningHoursResponse> MapopeningHoursListDtoToOpeningHoursListResponse(List<OpeningHourDto> openninghours)
        {
            var response = new List<OpeningHoursResponse>();

            foreach(var openingHoursDto in openninghours)
            {
                response.Add(MapopeningHoursDtoToOpeningHoursResponse(openingHoursDto));
            }
            return response;
        }
    }
}
