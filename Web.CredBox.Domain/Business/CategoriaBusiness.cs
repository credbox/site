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
    public class CategoriaBusiness:BaseBusiness
    {
        /// <summary>
        /// Evento de log
        /// </summary>
        public override event LogEventHandler Logging;
        private readonly ICategoria _repository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="repository"></param>
        public CategoriaBusiness(ICategoria repository)
        {
            _repository = repository;
        }

        public bool Add(CategoriaEntity categoria)
        {
            try
            {
                return _repository.Add(categoria);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("CategoriaBusiness", "Erro ao tentar inserir a categoria", ex));

                throw new Exception();
            }
        }
        public bool Edit(CategoriaEntity categoria)
        {
            try
            {
                return _repository.Edit(categoria);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("CategoriaBusiness", "Erro ao tentar editar a categoria", ex));

                throw new Exception();
            }
        }

        public CategoriaEntity GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("CategoriaBusiness", "Erro ao tentar carregar a categoria por Id", ex));

                throw new Exception();
            }
        }


        public IList<CategoriaEntity> GetAll()
        {
            try
            {
                return _repository.GetAll();
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("CategoriaBusiness", "Erro ao tentar carregar todos as categorias", ex));
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
