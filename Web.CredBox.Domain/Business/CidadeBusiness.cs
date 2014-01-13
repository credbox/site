using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.CredBox.Data.Provider;
using Web.CredBox.Domain.BusinessEvent;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Domain.Business
{
    public class CidadeBusiness:BaseBusiness
    {
        /// <summary>
        /// Evento de log
        /// </summary>
        public override event LogEventHandler Logging;
        private readonly ICidade _repository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="repository"></param>
        public CidadeBusiness(ICidade repository)
        {
            _repository = repository;
        }

        public IList<CidadeEntity> GetByIdEstado(int id)
        {
            try
            {
                return _repository.GetByIdEstado(id);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("CidadeBusiness", "Erro ao tentar carregar todos as cidades por estado", ex));
                throw new Exception();
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
