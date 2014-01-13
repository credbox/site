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
    public class FaleConoscoBusiness : BaseBusiness
    {
        /// <summary>
        /// Evento de log
        /// </summary>
        public override event LogEventHandler Logging;
        private readonly IFaleConosco _repository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="repository"></param>
        public FaleConoscoBusiness(IFaleConosco repository)
        {
            _repository = repository;
        }

        public bool Add(FaleConoscoEntity faleConosco)
        {
            try
            {
                return _repository.Add(faleConosco);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("FaleConoscoBusiness", "Erro ao tentar inserir o faleconosco", ex));

                throw new Exception();
            }
        }
        public bool Edit(FaleConoscoEntity faleConosco)
        {
            try
            {
                return _repository.Edit(faleConosco);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("FaleConoscoBusiness", "Erro ao tentar editar o faleconosco", ex));

                throw new Exception();
            }
        }

        public FaleConoscoEntity GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("FaleConoscoBusiness", "Erro ao tentar carregar o faleconosco por Id", ex));

                throw new Exception();
            }
        }


        public IList<FaleConoscoEntity> GetAllByStatus(bool ativo)
        {
            try
            {
                return _repository.GetAllByStatus(ativo);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("FaleConoscoBusiness", "Erro ao tentar carregar todos os faleconoscos por status", ex));
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
