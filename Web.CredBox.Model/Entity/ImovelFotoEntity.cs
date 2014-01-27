using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.CredBox.Model.Entity
{
    public class ImovelFotoEntity:IEntity
    {
        public int id { get; set; }
        public ImovelEntity Imovel { get; set; }
        public string fotoCaminho { get; set; }
        public string fotoNome { get; set; }
        public string fotoExtensao { get; set; }
    }
}
