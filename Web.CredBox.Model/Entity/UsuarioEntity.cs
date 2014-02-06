using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web.CredBox.Model.Entity
{
    public class UsuarioEntity : IEntity
    {
        public int id { get; set; }
        public ImobiliariaEntity Imobiliaria { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string email { get; set; }
        [Required]
        public string login { get; set; }
        [Required]
        public string senha { get; set; }
        [Required]
        public bool imobiliaria { get; set; }
        [Required]
        public bool ativo { get; set; }
        [Required]
        public bool emailNotificacao { get; set; }

        public bool Administrar { get; set; }
        public DateTime dataInclusao { get; set; }
        public UsuarioEntity UsuarioInclusao { get; set; }
    }
}
