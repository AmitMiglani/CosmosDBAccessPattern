using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBAPIExample.Models
{
    using Newtonsoft.Json;

    public class TelemetryDataMessage
    {
        [JsonProperty(PropertyName = "telemetryMessageBody")]
        public DeviceTelemetryData DeviceTelemetryData { get; set; }
    }

    public class DeviceTelemetryData
    {
        [JsonProperty(PropertyName = "id")]
        public string DeviceId { get; set; }

        [JsonProperty(PropertyName = "request")]
        public string RequestType { get; set; }

        [JsonProperty(PropertyName = "pressure_status")]
        public int PressureChamber { get; set; }

        [JsonProperty(PropertyName = "specific_gravity")]
        public int SpecificGravity { get; set; }
       
    }
}
