using Microsoft.Extensions.Logging;
using System;

namespace TechTest.Back.Commons.Utils
{
    /// <summary>
    /// Excepciones asociadas a la capa de Dominio de negocío
    /// </summary>
    [Serializable]
    public class DomainException : Exception
    {
        /// <summary>
        /// Contrucutor por parámetro
        /// </summary>
        /// <param name="message">mensaje de error</param>
        public DomainException(ILoggerFactory loggerFactory, string message)
            : base(message)
        {
            ILogger _logger = loggerFactory.CreateLogger<DomainException>();
            _logger.Log(LogLevel.Error, "Business Domain Error {message} ", message);
        }
        /// <summary>
        /// Contrucutor por parámetro
        /// </summary>
        /// <param name="message">Cadena de mensaje</param>
        /// <param name="exception"></param>
        public DomainException(ILoggerFactory loggerFactory, string message, Exception exception)
            : base(message, exception)
        {
            ILogger _logger = loggerFactory.CreateLogger<DomainException>();
            _logger.Log(LogLevel.Error, "Business Domain Error {message} ", message);
        }

    }
}
