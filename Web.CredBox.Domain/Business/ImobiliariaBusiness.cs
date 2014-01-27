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
    public class ImobiliariaBusiness : BaseBusiness
    {
        /// <summary>
        /// Evento de log
        /// </summary>
        public override event LogEventHandler Logging;
        private readonly IImobiliaria _repository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="repository"></param>
        public ImobiliariaBusiness(IImobiliaria repository)
        {
            _repository = repository;
        }

        public bool Add(ImobiliariaEntity imobiliaria)
        {
            try
            {
                return _repository.Add(imobiliaria);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("ImobiliariaBusiness", "Erro ao tentar inserir a imobiliaria", ex));

                throw new Exception();
            }
        }
        public bool Edit(ImobiliariaEntity imobiliaria)
        {
            try
            {
                return _repository.Edit(imobiliaria);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("ImobiliariaBusiness", "Erro ao tentar editar a imobiliaria", ex));

                throw new Exception();
            }
        }

        public ImobiliariaEntity GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("ImobiliariaBusiness", "Erro ao tentar carregar a imobiliaria por Id", ex));

                throw new Exception();
            }
        }


        public IList<ImobiliariaEntity> GetAllByStatus(bool ativo)
        {
            try
            {
                return _repository.GetAllByStatus(ativo);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("ImobiliariaBusiness", "Erro ao tentar carregar todos as imobiliarias por status", ex));
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