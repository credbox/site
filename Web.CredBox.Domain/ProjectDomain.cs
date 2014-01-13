using System;
using Web.CredBox.Domain.Business;
using Web.CredBox.Data.Repositories;

namespace Web.CredBox.Domain
{
    /// <summary>
    /// Classe que conterá todas as chamadas para as classes de negócio
    /// </summary>
    public class ProjectDomain : DomainEntry
    {

        private UsuarioBusiness usuarioBusiness;
        private EstadoBusiness estadoBusiness;
        private CidadeBusiness cidadeBusiness;
        private AssuntoBusiness assuntoBusiness;
        private CategoriaBusiness categoriaBusiness;
        private FaleConoscoBusiness faleConoscoBusiness;
        private ImobiliariaBusiness imobiliariaBusiness;
        private ImovelBusiness imovelBusiness;
        private TipoBusiness tipoBusiness;
        private LogBusiness logBusiness;


        /// <summary>
        /// Classe de teste de log
        /// </summary>
        public LogBusiness LogBusiness
        {
            get
            {
                if (logBusiness == null)
                    logBusiness = new LogBusiness();

                return logBusiness;
            }
        }

        /// <summary>
        /// Assunto
        /// </summary>
        public AssuntoBusiness AssuntoBusiness
        {
            get { return assuntoBusiness ?? (assuntoBusiness = new AssuntoBusiness(new AssuntoRepository())); }
        }

        /// <summary>
        /// Categoria
        /// </summary>
        public CategoriaBusiness CategoriaBusiness
        {
            get { return categoriaBusiness ?? (categoriaBusiness = new CategoriaBusiness(new CategoriaRepository())); }
        }

        /// <summary>
        /// Cidade
        /// </summary>
        public CidadeBusiness CidadeBusiness
        {
            get { return cidadeBusiness ?? (cidadeBusiness = new CidadeBusiness(new CidadeRepository())); }
        }

        /// <summary>
        /// Estado
        /// </summary>
        public EstadoBusiness EstadoBusiness
        {
            get { return estadoBusiness ?? (estadoBusiness = new EstadoBusiness(new EstadoRepository())); }
        }

        /// <summary>
        /// FaleConosco
        /// </summary>
        public FaleConoscoBusiness FaleConoscoBusiness
        {
            get { return faleConoscoBusiness ?? (faleConoscoBusiness = new FaleConoscoBusiness(new FaleConoscoRepository())); }
        }

        /// <summary>
        /// Imobiliaria
        /// </summary>
        public ImobiliariaBusiness ImobiliariaBusiness
        {
            get { return imobiliariaBusiness ?? (imobiliariaBusiness = new ImobiliariaBusiness(new ImobiliariaRepository())); }
        }

        /// <summary>
        /// Imovel
        /// </summary>
        public ImovelBusiness ImovelBusiness
        {
            get { return imovelBusiness ?? (imovelBusiness = new ImovelBusiness(new ImovelRepository())); }
        }

        /// <summary>
        /// Tipo
        /// </summary>
        public TipoBusiness TipoBusiness
        {
            get { return tipoBusiness ?? (tipoBusiness = new TipoBusiness(new TipoRepository())); }
        }

        /// <summary>
        /// Usuário
        /// </summary>
        public UsuarioBusiness UsuarioBusiness
        {
            get { return usuarioBusiness ?? (usuarioBusiness = new UsuarioBusiness(new UsuarioRepository())); }
        }



        #region Dispose

        private bool disposed = false;
        /// <summary>
        /// Dispose
        /// </summary>
        public override void Dispose()
        {
            Dispose(true);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && !disposed)
            {
                disposed = true;
                GC.SuppressFinalize(this);
            }
        }

        #endregion
    }
}