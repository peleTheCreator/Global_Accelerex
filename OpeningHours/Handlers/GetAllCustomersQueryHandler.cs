using MediatR;
using Microsoft.Extensions.Logging;
using OpeningHours.Mapping;
using OpeningHours.Queries;
using OpeningHours.Reprositories;
using OpeningHours.Responses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OpeningHours.Handlers
{

    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllOpeningQuery, List<OpeningHoursResponse>>
    {
        private readonly IOpeningHoursRepository _openingHoursRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetAllCustomersQueryHandler> _logger;

        public GetAllCustomersQueryHandler(ILogger<GetAllCustomersQueryHandler> logger, IOpeningHoursRepository openingHoursRepository, IMapper mapper)
        {
            _logger = logger;
            _openingHoursRepository = openingHoursRepository;
            _mapper = mapper;
        }

        public async Task<List<OpeningHoursResponse>> Handle(GetAllOpeningQuery request, CancellationToken cancellationToken)
        {

            var openninghours = await _openingHoursRepository.GetOpeningHourDtoAsync();
            return _mapper.MapopeningHoursListDtoToOpeningHoursListResponse(openninghours);
        }
    }
}
