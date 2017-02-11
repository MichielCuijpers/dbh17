using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToBlockChain.Logging.Log4Net
{
    public interface ILogger : IDisposable
    {
        /// <summary>
        /// Log a message with the Debug level.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Debug(string message);

        /// <summary>
        /// Log a message with the Debug level with formatting.
        /// </summary>
        /// <param name="message">A composite format string</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Debug(string message, params object[] args);

        /// <summary>
        /// Log a message with the Error level.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Error(string message);

        /// <summary>
        /// Log a message with the Error level with formatting.
        /// </summary>
        /// <param name="message">A composite format string</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Error(string message, params object[] args);

        /// <summary>
        /// Log a message with the Error level.
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="ex">The exception to be logged.</param>
        void Error(string message, Exception ex);

        /// <summary>
        /// Log a message with the Error level with formatting.
        /// </summary>
        /// <param name="message">A composite format string</param>
        /// <param name="ex">The exception.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Error(string message, Exception ex, params object[] args);

        /// <summary>
        /// Log a message with the Fatal level.
        /// </summary>
        /// <param name="message">The message to log</param>
        /// <param name="ex">The <see cref="System.Exception"/> that caused the fatal situation.</param>
        void Fatal(string message, Exception ex);

        /// <summary>
        /// Log a message with the Fatal level with formatting.
        /// </summary>
        /// <param name="message">A composite format string</param>
        /// <param name="ex">The exception.</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Fatal(string message, Exception ex, params object[] args);

        /// <summary>
        /// Log a message with the Info level.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Info(string message);

        /// <summary>
        /// Log a message with the Info level with formatting.
        /// </summary>
        /// <param name="message">A composite format string</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        void Info(string message, params object[] args);

        /// <summary>
        /// Log a message with the Warn level.
        /// </summary>
        /// <param name="message">The message to log</param>
        void Warn(string message);

        /// <summary>
        /// Log a message with the Warn level with formatting.
        /// </summary>
        /// <param name="message">A composite format string</param>
        /// <param name="args">An object array that contains zero or more objects to format.</param>
        /// 
        void Warn(string message, params object[] args);
    }
}
