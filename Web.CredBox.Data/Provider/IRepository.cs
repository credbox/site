using System;

namespace Web.CredBox.Data.Provider
{
    /// <summary>
    /// Interface padrão
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IRepositoryBase where T : class
    {
    }
}
