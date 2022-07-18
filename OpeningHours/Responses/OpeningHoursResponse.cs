using System;
using System.Collections.Generic;

namespace OpeningHours.Responses
{
    public class OpeningHoursResponse
    {
        public Guid Id { get; set; }
        public List<string> Opening { get; set; } = new List<string>();

    }
}
