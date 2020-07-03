using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using CosmosDBAPIExample.Models;
using CosmosDBAPIExample.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace CosmosDBAPIExample.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class RevosTissueProcessorAPI : Controller
    {
        private readonly ICosmosDBService _cosmosDBService;
        private readonly ICosmosTableService _cosmosTableService;

        public RevosTissueProcessorAPI(ICosmosDBService cosmosDBService, ICosmosTableService cosmosTableService)
        {
            _cosmosDBService = cosmosDBService;
            _cosmosTableService = cosmosTableService;
        }

        [HttpGet]
        [Route("")]
        [Route("deviceMetadata/{deviceId}")]
        public async Task<IEnumerable<DeviceMetadataTelemetryMessage>> DeviceData(string deviceId)
        {
            
            string deviceParamValue = deviceId + "_updatemetadata_updatemetadata";

            QueryDefinition queryDefinition = new QueryDefinition("SELECT top 1 " +
                "c.telemetryMessageBody" +
                " from c where c.deviceIdAndMessageType = @deviceParams ORDER BY c._ts DESC")
                .WithParameter("@deviceParams", deviceParamValue);

            ProvisionedDeviceMetadata deviceMetadata = await _cosmosTableService.InsertDeviceData(deviceId);
            return await _cosmosDBService.GetDeviceMetadata(queryDefinition);
        }

        [HttpGet]        
        [Route("deviceTelemetry/{deviceId}")]
        public async Task<IEnumerable<TelemetryDataMessage>> DeviceTelemetryData(string deviceId)
        {
            string deviceParamValue = deviceId + "_senddata_telemetry";

            QueryDefinition queryDefinition = new QueryDefinition("SELECT top 1 " +
                "c.telemetryMessageBody" +
                " from c where c.deviceIdAndMessageType = @deviceParams ORDER BY c._ts DESC")
                .WithParameter("@deviceParams", deviceParamValue);
                //.WithParameter("@dataType", "telemetry");

            return await _cosmosDBService.GetDeviceTelemetryData(queryDefinition);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
