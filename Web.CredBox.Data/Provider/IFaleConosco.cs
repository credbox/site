using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Data.Provider
{
    public interface IFaleConosco : IRepository<FaleConoscoEntity>
    {
        bool Add(FaleConoscoEntity faleConosco);
        bool Edit(FaleConoscoEntity faleConosco);
        IList<FaleConoscoEntity> GetAllByStatus(bool ativo);
        FaleConoscoEntity GetById(int id);
    }
}
