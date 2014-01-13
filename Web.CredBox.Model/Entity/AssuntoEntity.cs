using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.CredBox.Model.Entity
{
    public class AssuntoEntity : IEntity
    {
        public int id { get; set; }
        public string nome { get; set; }
        public DateTime dataInclusao { get; set; }
        public UsuarioEntity UsuarioInclusao { get; set; }
    }
}
