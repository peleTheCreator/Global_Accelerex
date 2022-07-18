
using System;
using System.Collections.Generic;
using OpeningHours.Responses;
using MediatR;
using Newtonsoft.Json;

namespace OpeningHours.Commands
{
    public class CreateOpeningHoursCommand : IRequest<OpeningHoursResponse>
    {
        public CreateOpeningHoursCommand()
        {
            monday = new List<OpeningHourData>();
            tuesday = new List<OpeningHourData>();
            wednesday = new List<OpeningHourData>();
            thursday = new List<OpeningHourData>();
            friday = new List<OpeningHourData>();
            saturday = new List<OpeningHourData>();
            sunday = new List<OpeningHourData>();
        }
        [JsonProperty("monday")]
        public List<OpeningHourData> monday { get; set; }
        [JsonProperty("tuesday")]
        public List<OpeningHourData> tuesday { get; set; }
        [JsonProperty("wednesday")]
        public List<OpeningHourData> wednesday { get; set; }
        [JsonProperty("thursday")]
        public List<OpeningHourData> thursday { get; set; }
        [JsonProperty("friday")]
        public List<OpeningHourData> friday { get; set; }
        [JsonProperty("saturday")]
        public List<OpeningHourData> saturday { get; set; }
        [JsonProperty("sunday")]
        public List<OpeningHourData> sunday { get; set; }
    }

    public class OpeningHourData
    {
        public string type { get; set; }
        public long value { get; set; }
    }


}


