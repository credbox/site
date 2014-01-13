using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.CredBox.Model.Entity
{
    public class UsuarioEntity:IEntity
    {
        public int id { get; set; }
        public ImobiliariaEntity Imobiliaria { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public bool imobiliaria { get; set; }
        public bool ativo { get; set; }
        public bool emailNotificacao { get; set; }
        public DateTime dataInclusao { get; set; }
        public UsuarioEntity UsuarioInclusao { get; set; }
    }
}
