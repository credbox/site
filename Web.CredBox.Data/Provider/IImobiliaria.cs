using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Data.Provider
{
    public interface IImobiliaria : IRepository<ImobiliariaEntity>
    {
        bool Add(ImobiliariaEntity imobiliaria);
        bool Edit(ImobiliariaEntity imobiliaria);
        IList<ImobiliariaEntity> GetAllByStatus(int idEstado, int idCidade, string nome, bool status);
        ImobiliariaEntity GetById(int id);
    }
}

