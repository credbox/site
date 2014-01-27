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
    public class UsuarioBusiness:BaseBusiness
    {
         /// <summary>
        /// Evento de log
        /// </summary>
        public override event LogEventHandler Logging;
        private readonly IUsuario _repository; 

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="repository"></param>
        public UsuarioBusiness(IUsuario repository)
        {
            _repository = repository;
        }

        public bool Add(UsuarioEntity usuario)
        {
            try
            {
                return _repository.Add(usuario);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("UsuarioBusiness", "Erro ao tentar inserir o usuário", ex));

                throw new Exception();
            }
        }
        public bool Edit(UsuarioEntity usuario)
        {
            try
            {
                return _repository.Edit(usuario);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("UsuarioBusiness", "Erro ao tentar editar o usuário", ex));

                throw new Exception();
            }
        }

        public UsuarioEntity GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("UsuarioBusiness", "Erro ao tentar carregar o usuário por Id", ex));

                throw new Exception();
            }
        }


        public IList<UsuarioEntity> GetAllByStatus(bool ativo)
        {
            try
            {
                return _repository.GetAllByStatus(ativo);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("UsuarioBusiness", "Erro ao tentar carregar todos os usuários", ex));
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
