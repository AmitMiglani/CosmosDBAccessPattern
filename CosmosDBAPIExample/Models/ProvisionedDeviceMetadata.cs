namespace CosmosDBAPIExample.Models
{
    using Microsoft.Azure.Cosmos.Table;

    public class ProvisionedDeviceMetadata : TableEntity
    {
       

       public ProvisionedDeviceMetadata()
        { 

        }

        public ProvisionedDeviceMetadata(string tenantDeviceTypeTopicKey, string deviceId)
        {
            PartitionKey = tenantDeviceTypeTopicKey;
            RowKey = deviceId;
        }

        public string DeviceName { get; set; }

        public string DeviceRegion { get; set; }

        public string DeviceTimezone { get; set; }

    }
}
