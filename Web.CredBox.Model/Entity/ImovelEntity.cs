using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web.CredBox.Model.Entity
{
    public class ImovelEntity : IEntity
    {
        public int id { get; set; }
        [Required]
        public ImobiliariaEntity Imobiliaria { get; set; }
        [Required]
        public CategoriaEntity Categoria { get; set; }
        [Required]
        public TipoEntity Tipo { get; set; }
        [Required]
        public EstadoEntity Estado { get; set; }
        [Required]
        public CidadeEntity Cidade { get; set; }
        [Required]
        public string endereco { get; set; }
        [Required]
        public string bairro { get; set; }
        [Required]
        public int numero { get; set; }
        public string complemento { get; set; }
        [Required]
        public string cep { get; set; }
        public string codigoImobiliaria { get; set; }
        [Required]
        public int vagagaragem { get; set; }
        [Required]
        public int quantidadeSuite { get; set; }
        [Required]
        public int quantidadeQuarto { get; set; }
        [Required]
        public int areaTerreno { get; set; }
        [Required]
        public int areaConstruida { get; set; }
        [Required]
        public bool aceitaFinanciamento { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal valor { get; set; }
        public bool publicar { get; set; }
        public bool vendido { get; set; }
        [Required]
        public bool destaque { get; set; }
        public string caminhoFotoDestaque { get; set; }
        public string nomeFotoDestaque { get; set; }
        public string extensaoFotoDestaque { get; set; }
        [Required]
        public string caminhoFotoPrincipal { get; set; }
        [Required]
        public string nomeFotoPrinciapl { get; set; }
        [Required]
        public string extensaoFotoPrincipal { get; set; }
        [Required]
        public string descricao { get; set; }
        public UsuarioEntity UsuarioPublicacao { get; set; }
        public DateTime dataInclusao { get; set; }
        public UsuarioEntity UsuarioInclusao { get; set; }
        public DateTime dataAtualizacao { get; set; }
        public UsuarioEntity UsuarioAtualizacao { get; set; }
    }
}
