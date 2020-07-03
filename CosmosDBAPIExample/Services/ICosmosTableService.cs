using CosmosDBAPIExample.Models;
using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CosmosDBAPIExample.Services
{
    public interface ICosmosTableService    {
        Task<ProvisionedDeviceMetadata> InsertDeviceData(string query);                
    }
}
