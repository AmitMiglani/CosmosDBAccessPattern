using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using CosmosDBAPIExample.Models;

namespace CosmosDBAPIExample.Services
{
    public class CosmosTableService : ICosmosTableService
    {
        private CloudTableClient _cloudTableClient;
        private string _tableName;
        public CloudTable table;

        public CosmosTableService(CloudTableClient cloudTableClient, string tableName) 
        {
            _cloudTableClient = cloudTableClient;
            _tableName = tableName;
            table = cloudTableClient.GetTableReference(tableName);
        }

        public async Task<ProvisionedDeviceMetadata> InsertDeviceData(string query)
        {
            ProvisionedDeviceMetadata provisionedDevice = new ProvisionedDeviceMetadata("Epredia_RevosTissueProcessor_DeviceMetadata","amitmiglani@gmail.com" + "_" + query)
            {
                DeviceName = "Fav2",
                DeviceRegion = "UK",
                DeviceTimezone = "+0530"
            };

            try
            {
                // Create the InsertOrReplace table operation
                TableOperation insertOrMergeOperation = TableOperation.InsertOrMerge(provisionedDevice);

                // Execute the operation.
                TableResult result = await table.ExecuteAsync(insertOrMergeOperation);
                ProvisionedDeviceMetadata insertedDevice = result.Result as ProvisionedDeviceMetadata;

                if (result.RequestCharge.HasValue)
                {
                    Console.WriteLine("Request Charge of InsertOrMerge Operation: " + result.RequestCharge);
                }

                return insertedDevice;
            }
            catch (StorageException e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
                throw;
            }


            //return null;
        }
    }
}
