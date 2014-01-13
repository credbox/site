using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Data.Provider
{
    public interface IEstado : IRepository<EstadoEntity>
    {
        IList<EstadoEntity> GetAll();
    }
}
