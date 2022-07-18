using OpeningHours.Dtos;
using OpeningHours.Responses;
using System.Collections.Generic;

namespace OpeningHours.Mapping
{
    public interface IMapper
    {
        OpeningHoursResponse MapopeningHoursDtoToOpeningHoursResponse(OpeningHourDto openingHours);
        List<OpeningHoursResponse> MapopeningHoursListDtoToOpeningHoursListResponse(List<OpeningHourDto> openninghours);
    }
}
