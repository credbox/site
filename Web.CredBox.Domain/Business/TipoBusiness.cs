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
    public class TipoBusiness : BaseBusiness
    {
        /// <summary>
        /// Evento de log
        /// </summary>
        public override event LogEventHandler Logging;
        private readonly ITipo _repository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="repository"></param>
        public TipoBusiness(ITipo repository)
        {
            _repository = repository;
        }

        public bool Add(TipoEntity tipo)
        {
            try
            {
                return _repository.Add(tipo);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("TipoBusiness", "Erro ao tentar inserir o tipo", ex));

                throw new Exception();
            }
        }
        public bool Edit(TipoEntity tipo)
        {
            try
            {
                return _repository.Edit(tipo);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("TipoBusiness", "Erro ao tentar editar o tipo", ex));

                throw new Exception();
            }
        }

        public TipoEntity GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("TipoBusiness", "Erro ao tentar carregar o tipo por Id", ex));

                throw new Exception();
            }
        }


        public IList<TipoEntity> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("TipoBusiness", "Erro ao tentar carregar todos os tipos", ex));
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
