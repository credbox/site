using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Web.CredBox.Data.Provider;

namespace Web.CredBox.Data
{
    /// <summary>
    /// Provider Repository
    /// </summary>
    class ProviderRepository : RepositoryFactoryProvider
    {
        private static Type[] _types;

        /// <summary>
        /// Carrega o repository
        /// </summary>
        /// <typeparam name="T">Repository solicitado</typeparam>
        /// <returns>Retorna a repository solicitado em T</returns>
        public override T GetRepository<T>()
        {
            var types = Types.Where(t => t.GetInterface(typeof(T).Name) != null).FirstOrDefault();
            return (T)Activator.CreateInstance(types);
        }

        private IEnumerable<Type> Types
        {
            get
            {
                return _types ?? (_types = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterface(typeof(IRepositoryBase).Name) != null && t.Namespace == GetType().Namespace).ToArray());
            }
        }
    }
}
