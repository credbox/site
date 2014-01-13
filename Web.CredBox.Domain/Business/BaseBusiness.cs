using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.CredBox.Domain.BusinessEvent;

namespace Web.CredBox.Domain.Business
{
    /// <summary>
    /// BaseBusiness
    /// </summary>
    public abstract class BaseBusiness : LogEvent, IDisposable
    {
        /// <summary>
        /// Evento de log
        /// </summary>
        public abstract event LogEventHandler Logging;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        public BaseBusiness()
        {
            this.Logging += new LogEventHandler(AddLog);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing){}
    }

    /// <summary>
    /// Evento para criação do log
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void LogEventHandler(object sender, LogEventArgs e);
}
