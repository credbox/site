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
    public class AssuntoBusiness : BaseBusiness
    {
        /// <summary>
        /// Evento de log
        /// </summary>
        public override event LogEventHandler Logging;
        private readonly IAssunto _repository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="repository"></param>
        public AssuntoBusiness(IAssunto repository)
        {
            _repository = repository;
        }

        public bool Add(AssuntoEntity assunto)
        {
            try
            {
                return _repository.Add(assunto);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("AssuntoBusiness", "Erro ao tentar inserir o assunto", ex));

                throw new Exception();
            }
        }
        public bool Edit(AssuntoEntity assunto)
        {
            try
            {
                return _repository.Edit(assunto);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("AssuntoBusiness", "Erro ao tentar editar o assunto", ex));

                throw new Exception();
            }
        }

        public AssuntoEntity GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("AssuntoBusiness", "Erro ao tentar carregar o assunto por Id", ex));

                throw new Exception();
            }
        }


        public IList<AssuntoEntity> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("AssuntoBusiness", "Erro ao tentar carregar todos os assuntos", ex));
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
