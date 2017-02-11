using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToBlockChain.Configuration
{
    public class ConfigurationManager
    {
        public ConfigurationManager()
        {

        }

        public static List<ConfigurationSettings> GetConfiguration(string configurationGroup)
        {
            var configurationSettings = new List<ConfigurationSettings>();

            // Retrieve the storage account from the connection string.
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("ToBlockChain.Configuration.StorageContext"));

            // Create the table client.
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            // Create the CloudTable object that represents the "people" table.
            CloudTable table = tableClient.GetTableReference("ConfigurationSettings");

            // Create the table query.
            TableQuery<ConfigurationSettings> rangeQuery = new TableQuery<ConfigurationSettings>().Where(
                    TableQuery.GenerateFilterCondition("ConfigurationGroup", QueryComparisons.Equal, configurationGroup));
            
            foreach (ConfigurationSettings config in table.ExecuteQuery(rangeQuery))
            {
                configurationSettings.Add(config);
            }

            return configurationSettings;
        }
    }
}
