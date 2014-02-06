using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Data.Provider
{
    public interface IImovel : IRepository<ImovelEntity>
    {
        int Add(ImovelEntity imovel);
        bool Edit(ImovelEntity imovel);
        IList<ImovelEntity> GetAll(int idimobiliaria, bool publicar, bool vendido, string nome, string codigoimobiliaria, int idCategoria, int idTipo, int idEstado, int idCidade);
        ImovelEntity GetById(int id);
        IList<ImovelEntity> GetAllDestaque();

        bool AddImages(ImovelEntity imovel);
    }
}
