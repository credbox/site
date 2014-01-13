using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Domain.BusinessEvent
{
    /// <summary>
    /// Classe de evento do log
    /// </summary>
    public class LogEventArgs : EventArgs
    {
        /// <summary>
        /// Propriedade do tipo LogEntity
        /// </summary>
        public LogEntity LogEntity { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="loggerName"></param>
        /// <param name="loggerMessage"></param>
        /// <param name="loggerException"></param>
        public LogEventArgs(string loggerName, string loggerMessage, Exception loggerException)
        {
            LogEntity = new LogEntity(loggerName, loggerMessage, loggerException);            
        }
    }
}
