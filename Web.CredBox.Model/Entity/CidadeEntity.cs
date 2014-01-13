using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.CredBox.Model.Entity
{
    public class CidadeEntity : IEntity
    {
        public int id { get; set; }
        public EstadoEntity IdEstado { get; set; }
        public string nome { get; set; }
    }
}
