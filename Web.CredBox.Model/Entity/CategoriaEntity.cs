using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web.CredBox.Model.Entity
{
    public class CategoriaEntity : IEntity
    {
        public int id { get; set; }
        [Required]
        public string nome { get; set; }
        public DateTime dataInclusao { get; set; }
        public UsuarioEntity UsuarioInclusao { get; set; }
    }
}
