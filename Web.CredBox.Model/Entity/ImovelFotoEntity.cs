using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web.CredBox.Model.Entity
{
    public class ImovelFotoEntity:IEntity
    {
        public int id { get; set; }
        [Required]
        public ImovelEntity Imovel { get; set; }
        [Required]
        public string fotoCaminho { get; set; }
        [Required]
        public string fotoNome { get; set; }
        [Required]
        public string fotoExtensao { get; set; }
    }
}
