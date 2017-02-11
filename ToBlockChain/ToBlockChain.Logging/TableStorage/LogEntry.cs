using Microsoft.WindowsAzure.Storage.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToBlockChain.Logging.TableStorage
{
    public class LogEntry : TableEntity
    {
        public LogEntry()
        {
            var now = DateTime.UtcNow;
            PartitionKey = string.Format("{0:yyyy-MM}", now);
            RowKey = string.Format("{0:dd HH:mm:ss.fff}-{1}", now, Guid.NewGuid());
        }
        #region Table columns  
        public string Message { get; set; }
        public string Level { get; set; }
        public string LoggerName { get; set; }
        public string Domain { get; set; }
        public string ThreadName { get; set; }
        public string Identity { get; set; }
        public string RoleInstance { get; set; }
        public string DeploymentId { get; set; }
        #endregion
    }
}
