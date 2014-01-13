using System;
using System.IO;
using log4net.Config;

namespace Web.CredBox.Domain.BusinessEvent
{
    /// <summary>
    /// Classe de evento
    /// </summary>
    public class LogEvent
    {
        /// <summary>
        /// Adicionando o log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AddLog(object sender, LogEventArgs e)
        {
            XmlConfigurator.Configure(new FileInfo(Util.Configurations.LogFileConfiguration));

            var logger = log4net.LogManager.GetLogger("LogInFile");
            logger.Error(e.LogEntity.Message, e.LogEntity.Exception);
        }
    }

    /// <summary>
    /// Evento responsável por gerar o log
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void LogEventHandler(object sender, LogEventArgs e);
}
