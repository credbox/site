using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.CredBox.Model.Entity
{
    public class ImobiliariaEntity:IEntity
    {
        public int id { get; set; }
        public EstadoEntity Estado { get; set; }
        public CidadeEntity Cidade { get; set; }
        public string nome { get; set; }
        public string endereco { get; set; }
        public string cep { get; set; }
        public int numero { get; set; }
        public string bairro { get; set; }
        public string contato { get; set; }
        public string telefoneContato { get; set; }
        public string celularContato { get; set; }
        public string emailContato { get; set; }
        public string complemento { get; set; }
        public bool ativo { get; set; }
        public DateTime dataInclusao { get; set; }
        public UsuarioEntity UsuarioInclusao { get; set; }
    }
}
