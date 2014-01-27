using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Data.Provider
{
    public interface IUsuario:IRepository<UsuarioEntity>
    {
        bool Add(UsuarioEntity usuario);
        bool Edit(UsuarioEntity usuario);
        IList<UsuarioEntity> GetAllByStatus(string nome, string email, string login, int idimobiliaria, bool ativo);
        UsuarioEntity GetById(int id);
    }
}
