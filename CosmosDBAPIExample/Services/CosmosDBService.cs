using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using CosmosDBAPIExample.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Fluent;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CosmosDBAPIExample.Services
{
    public class CosmosDBService : ICosmosDBService
    {
        private Container _container;
        public IConfiguration _Configuration;

        public CosmosDBService(
            CosmosClient dbClient,
            string databaseName,
            string containerName)
        {
            this._container = dbClient.GetContainer(databaseName, containerName);

        }

        public async Task<IEnumerable<TelemetryDataMessage>> GetDeviceTelemetryData(QueryDefinition queryString)
        {
            var query = this._container.GetItemQueryIterator<TelemetryDataMessage>(queryString);

            List<TelemetryDataMessage> results = new List<TelemetryDataMessage>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            return results;
        }
        
        public async Task<IEnumerable<DeviceMetadataTelemetryMessage>> GetDeviceMetadata(QueryDefinition queryString )
        {
            
            var query = this._container.GetItemQueryIterator<DeviceMetadataTelemetryMessage>(queryString);
            
            List<DeviceMetadataTelemetryMessage> results = new List<DeviceMetadataTelemetryMessage>();

            while (query.HasMoreResults)
            {
                var response = await query.ReadNextAsync();

                results.AddRange(response.ToList());
            }

            //FeedIterator feedIterator = this._container.GetItemQueryStreamIterator(queryString);
            //while (feedIterator.HasMoreResults)
            //{
            //    using (ResponseMessage response = await feedIterator.ReadNextAsync())
            //    {
            //        using (StreamReader sr = new StreamReader(response.Content))
            //        using (JsonTextReader jtr = new JsonTextReader(sr))
            //        {
            //            JObject result = JObject.Load(jtr);
            //            var dcouemnt = result.GetValue("Documents")[0];
            //            var docString = dcouemnt.ToString();

            //            DeviceMetadataTelemetryMessage a = JsonConvert.DeserializeObject<DeviceMetadataTelemetryMessage>(docString);
            //            //DeviceMetadata dm = new DeviceMetadata() { };
            //        }
            //    }
            //}

            return results;            
        }

        //public async Task<DeviceMetadata> GetDeviceMetadata(string deviceId)
        //{
        //    try
        //    {
        //        ItemResponse<DeviceMetadata> response = await this._container.ReadItemAsync<DeviceMetadata>(deviceId, new PartitionKey(deviceId + "_" + "updateMetadata"));
        //        return response.Resource;
        //    }
        //    catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
        //    {
        //        return null;
        //    }            
        //}
    }
}
