using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBAPIExample.Models
{
    using Newtonsoft.Json;

    public class DeviceMetadataTelemetryMessage
    {
        [JsonProperty(PropertyName = "telemetryMessageBody")]
        public DeviceMetadata DeviceMetadataMessage { get; set; }
    }

    public class DeviceMetadata
    {
        [JsonProperty(PropertyName = "id")]
        public string DeviceId { get; set; }

        [JsonProperty(PropertyName = "request")]
        public string RequestType { get; set; }

        [JsonProperty(PropertyName = "chamber_status")]
        public string ChamberStatus { get; set; }

        [JsonProperty(PropertyName = "protocol_name")]
        public string ProtocolName { get; set; }

        [JsonProperty(PropertyName = "reagent_name")]
        public string ReagentName { get; set; }
    }
}
