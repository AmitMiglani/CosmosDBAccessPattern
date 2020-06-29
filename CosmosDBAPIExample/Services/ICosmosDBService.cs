using CosmosDBAPIExample.Models;
using Microsoft.Azure.Cosmos;
using System.Collections;
using System.Threading.Tasks;

namespace CosmosDBAPIExample.Services
{
    public interface ICosmosDBService
    {
        Task<System.Collections.Generic.IEnumerable<DeviceMetadataTelemetryMessage>> GetDeviceMetadata(QueryDefinition query);

        Task<System.Collections.Generic.IEnumerable<TelemetryDataMessage>> GetDeviceTelemetryData(QueryDefinition query);

        
    }
}