using OpeningHours.Commands;
using OpeningHours.Dtos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpeningHours.Reprositories
{
    public interface IOpeningHoursRepository
    {
        Task<OpeningHourDto> CreateOpeningHoursAsync(OpeningHourDto openingHourDto);
        Task<OpeningHourDto> GetOpeningHourDtoByIdAsync(Guid customerId);
        Task<List<OpeningHourDto>> GetOpeningHourDtoAsync();
    }
}
