using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTest.Commons.Helpers
{
    [Serializable]
    public class InfrastructureException : Exception
    {
        /// <summary>
        /// Contrucutor por parámetro
        /// </summary>
        /// <param name="message">mensaje de error</param>
        public InfrastructureException(ILoggerFactory loggerFactory, string message)
            : base(message)
        {
            ILogger _logger = loggerFactory.CreateLogger<InfrastructureException>();
            _logger.Log(LogLevel.Error, "Infrastructure Domain Error {message} ", message);
        }
        /// <summary>
        /// Contrucutor por parámetro
        /// </summary>
        /// <param name="message">Cadena de mensaje</param>
        /// <param name="exception"></param>
        public InfrastructureException(ILoggerFactory loggerFactory, string message, Exception exception)
            : base(message, exception)
        {
            ILogger _logger = loggerFactory.CreateLogger<InfrastructureException>();
            _logger.Log(LogLevel.Error, "Infrastructure Domain Error {message} ", message);
        }
    }
}
