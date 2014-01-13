using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.CredBox.Model.Entity
{
    public class FaleConoscoEntity : IEntity
    {
        public int id { get; set; }
        public ImovelEntity Imovel { get; set; }
        public AssuntoEntity Assunto { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string celular { get; set; }
        public string descricao { get; set; }
        public bool ativo { get; set; }
        public DateTime dataInclusao { get; set; }
    }
}
