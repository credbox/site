using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Web.CredBox.Domain.BusinessEvent;

namespace Web.CredBox.Domain.Business
{
    /// <summary>
    /// Classe de teste de log
    /// </summary>
    public class LogBusiness : BaseBusiness
    {
        internal LogBusiness() { }

        /// <summary>
        /// Evento de log
        /// </summary>
        public override event LogEventHandler Logging;

        /// <summary>
        /// Gerando log
        /// </summary>
        public void GeraLog()
        {
            try
            {
                int.Parse("a");
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("Teste Evento", "Testando Evento", ex));
            }
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {

        }
    }
}