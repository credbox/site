using System;

namespace Web.CredBox.Domain
{
    /// <summary>
    /// Classe DomainEntry
    /// </summary>
    public abstract class DomainEntry : IDisposable
    {
        /// <summary>
        /// Construtor
        /// </summary>
        protected DomainEntry() { }

        /// <summary>
        /// Dispose
        /// </summary>
        public abstract void Dispose();
    }
}
