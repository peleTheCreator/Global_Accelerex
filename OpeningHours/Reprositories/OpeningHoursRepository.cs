using OpeningHours.Commands;
using OpeningHours.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OpeningHours.Reprositories
{
    public class OpeningHoursRepository : IOpeningHoursRepository
    {
        private readonly List<OpeningHourDto> _openingHourDto = new List<OpeningHourDto>
        {
           
        };

        public Task<OpeningHourDto> CreateOpeningHoursAsync(OpeningHourDto openingHourDto)
        {
            openingHourDto.Id = Guid.NewGuid();
            _openingHourDto.Add(openingHourDto);

            return Task.FromResult(openingHourDto);

        }

        public Task<OpeningHourDto> GetOpeningHourDtoByIdAsync(Guid customerId)
        {
            return Task.FromResult(_openingHourDto.SingleOrDefault(x => x.Id == customerId));
        }

        public Task<List<OpeningHourDto>> GetOpeningHourDtoAsync()
        {
            return Task.FromResult(_openingHourDto);
        }
    }

}
