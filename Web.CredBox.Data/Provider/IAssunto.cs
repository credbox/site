using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Data.Provider
{
    public interface IAssunto : IRepository<AssuntoEntity>
    {
        bool Add(AssuntoEntity assunto);
        bool Edit(AssuntoEntity assunto);
        IList<AssuntoEntity> GetAll(string nome);
        AssuntoEntity GetById(int id);
    }
}
