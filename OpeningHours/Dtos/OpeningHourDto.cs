using System;
using System.Collections.Generic;

namespace OpeningHours.Dtos
{
    public class OpeningHourDto
    {
        public Guid Id { get; set; }
        public List<string> Opening { get; set; } = new List<string>();

    }

}
