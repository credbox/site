using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.CredBox.Data
{
    /// <summary>
    /// Classe abastrata
    /// </summary>
    public abstract class RepositoryFactoryProvider
    {
        /// <summary>
        /// Retorna a chamada da repository
        /// </summary>
        /// <typeparam name="T">Tipo de repositório</typeparam>
        /// <returns>Retorna a repostiroy</returns>
        public abstract T GetRepository<T>();
    }
}
