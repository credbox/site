using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Data.Provider
{
    public interface ITipo:IRepository<TipoEntity>
    {
        bool Add(TipoEntity tipo);
        bool Edit(TipoEntity tipo);
        IList<TipoEntity> GetAll(string nome);
        TipoEntity GetById(int id); 
    }
}
