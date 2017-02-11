using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToBlockChain.Logging.Log4Net
{
    public class Logger : ILogger
    {
        private readonly ILog _logger;
        public const string DefaultLogger = "ToBlockChain.Logging";
        
        #region cTor
        public Logger()
            : this(DefaultLogger)
        {
                        
        }

        public Logger(string name)
        {
            name = String.IsNullOrEmpty(name) ? DefaultLogger : name;
            _logger = LogManager.GetLogger(name);
        }
        #endregion

        public void SetLoggerProperty(string propertyName, object value)
        {
            GlobalContext.Properties[propertyName] = value;
        }

        public static void SetProperty(string propertyName, object value)
        {
            GlobalContext.Properties[propertyName] = value;
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
            FlushBuffers();
        }

        public void Debug(string message, params object[] args)
        {
            _logger.Debug(string.Concat(message, args));
            FlushBuffers();
        }

        public void Error(string message)
        {
            _logger.Error(message);
            FlushBuffers();
        }

        public void Error(string message, params object[] args)
        {
            _logger.Error(string.Concat(message, args));
            FlushBuffers();
        }

        public void Error(string message, Exception ex)
        {
            _logger.Error(message, ex);
            FlushBuffers();
        }

        public void Error(string message, Exception ex, params object[] args)
        {
            _logger.Error(string.Concat(message, args), ex);
            FlushBuffers();
        }

        public void Fatal(string message, Exception ex)
        {
            _logger.Fatal(message, ex);
            FlushBuffers();
        }

        public void Fatal(string message, Exception ex, params object[] args)
        {
            _logger.Fatal(string.Concat(message, args), ex);
            FlushBuffers();
        }

        public void Info(string message)
        {
            _logger.Info(message);
            FlushBuffers();
        }

        public void Info(string message, params object[] args)
        {
            _logger.Info(string.Concat(message, args));
            FlushBuffers();
        }

        public void Warn(string message)
        {
            _logger.Warn(message);
            FlushBuffers();
        }

        public void Warn(string message, params object[] args)
        {
            _logger.Warn(string.Concat(message, args));
            FlushBuffers();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }

        public void FlushBuffers()
        {
            ILoggerRepository rep = LogManager.GetRepository();
            foreach (IAppender appender in rep.GetAppenders())
            {
                var buffered = appender as BufferingAppenderSkeleton;
                if (buffered != null)
                {
                    buffered.Flush();
                }
            }
        }
    }
}
