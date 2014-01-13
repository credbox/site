using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Web.CredBox.Data
{
    /// <summary>
    /// Carrega a repository
    /// </summary>
    /// <typeparam name="T">Repository utilizada</typeparam>
    public static class Repository<T>
    {
        static RepositoryFactoryProvider _provider;
        /// <summary>
        /// Define o providor
        /// </summary>
        public static RepositoryFactoryProvider Provider
        {
            get { return _provider ?? (_provider = new ProviderRepository()); }
            set { _provider = value; }
        }
        /// <summary>
        /// Retorna o tipo repository
        /// </summary>
        /// <returns></returns>
        public static T GetRepository()
        {
            return Provider.GetRepository<T>();
        }
    }
}
