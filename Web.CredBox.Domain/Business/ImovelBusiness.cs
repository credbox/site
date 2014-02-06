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
    public class ImovelBusiness : BaseBusiness
    {
        /// <summary>
        /// Evento de log
        /// </summary>
        public override event LogEventHandler Logging;
        private readonly IImovel _repository;

        /// <summary>
        /// Construtor da classe
        /// </summary>
        /// <param name="repository"></param>
        public ImovelBusiness(IImovel repository)
        {
            _repository = repository;
        }

        public int Add(ImovelEntity imovel)
        {
            try
            {
                return _repository.Add(imovel);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("ImovelBusiness", "Erro ao tentar inserir o imovel", ex));

                throw new Exception();
            }
        }
        public bool Edit(ImovelEntity imovel)
        {
            try
            {
                return _repository.Edit(imovel);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("ImovelBusiness", "Erro ao tentar editar o imovel", ex));

                throw new Exception();
            }
        }

        public bool AddImages(ImovelEntity imovel)
        {
            try
            {
                return _repository.AddImages(imovel);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("ImovelBusiness", "Erro ao tentar inserir as imagens do imovel", ex));

                throw new Exception();
            }
        }

        public ImovelEntity GetById(int id)
        {
            try
            {
                return _repository.GetById(id);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("ImovelBusiness", "Erro ao tentar carregar o imovel por Id", ex));

                throw new Exception();
            }
        }


        public IList<ImovelEntity> GetAll(int idimobiliaria, bool publicar, bool vendido, string nome, string codigoimobiliaria, int idCategoria, int idTipo, int idEstado, int idCidade)
        {
            try
            {
                return _repository.GetAll(idimobiliaria, publicar, vendido, nome, codigoimobiliaria, idCategoria, idTipo, idEstado, idCidade);
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("ImovelBusiness", "Erro ao tentar carregar todos os imoveis", ex));
                throw new Exception();
            }
        }

        public IList<ImovelEntity> GetAllDestaque()
        {
            try
            {
                return _repository.GetAllDestaque();
            }
            catch (Exception ex)
            {
                if (Logging != null)
                    Logging.Invoke(this, new LogEventArgs("ImovelBusiness", "Erro ao tentar carregar todos os destaques", ex));
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
