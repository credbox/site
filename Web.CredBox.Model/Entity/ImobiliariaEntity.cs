using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web.CredBox.Model.Entity
{
    public class ImobiliariaEntity:IEntity
    {
        public int id { get; set; }
        [Required]
        public EstadoEntity Estado { get; set; }
        [Required]
        public CidadeEntity Cidade { get; set; }
        [Required]
        public string nome { get; set; }
        [Required]
        public string endereco { get; set; }
        [Required]
        public string cep { get; set; }
        [Required]
        public int numero { get; set; }
        [Required]
        public string bairro { get; set; }
        [Required]
        public string contato { get; set; }
        [Required]
        public string telefoneContato { get; set; }
        [Required]
        public string celularContato { get; set; }
        [Required]
        public string emailContato { get; set; }
        public string complemento { get; set; }
        
        public bool ativo { get; set; }
        public DateTime dataInclusao { get; set; }
        public UsuarioEntity UsuarioInclusao { get; set; }
    }
}
