using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.CredBox.Model.Entity
{
    public class LogEntity : IEntity
    {
        /// <summary>
        /// Método construtor
        /// </summary>
        /// <param name="name">Nome do log</param>
        /// <param name="message">Mensagem de erro</param>
        /// <param name="exception">A exceção gerada no erro</param>
        public LogEntity(string name, string message, Exception exception)
        {
            this.Name = name;
            this.Message = message;
            this.Exception = exception;
        }

        /// <summary>
        /// Nome do log de erro
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Mensagem de erro
        /// </summary>
        public string Message { get; private set; }
        /// <summary>
        /// Execeção gerada no erro
        /// </summary>
        public Exception Exception { get; private set; }
    }
}
