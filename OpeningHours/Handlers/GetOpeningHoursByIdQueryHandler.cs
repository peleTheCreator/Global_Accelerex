using System.Threading;
using System.Threading.Tasks;
using OpeningHours.Mapping;
using OpeningHours.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using OpeningHours.Reprositories;
using System.Collections.Generic;
using OpeningHours.Queries;

namespace OpeningHours.Handlers
{

    public class GetOpeningHoursByIdQueryHandler : IRequestHandler<GetOpeningHoursByIdQuery, OpeningHoursResponse>
    {
        private readonly IOpeningHoursRepository _openingHoursRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetOpeningHoursByIdQueryHandler> _logger;

        public GetOpeningHoursByIdQueryHandler(ILogger<GetOpeningHoursByIdQueryHandler> logger, IOpeningHoursRepository openingHoursRepository, IMapper mapper)
        {
            _logger = logger;
            _openingHoursRepository = openingHoursRepository;
            _mapper = mapper;
        }

       
        public async Task<OpeningHoursResponse> Handle(GetOpeningHoursByIdQuery request, CancellationToken cancellationToken)
        {
            var openingHourDto = await _openingHoursRepository.GetOpeningHourDtoByIdAsync(request.OpeningHoursId);
            return _mapper.MapopeningHoursDtoToOpeningHoursResponse(openingHourDto);
        }
    }
}
