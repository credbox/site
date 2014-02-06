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
        public string nome { get; set; }

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
        public decimal areaTerreno { get; set; }
        [Required]
        public decimal areaConstruida { get; set; }
        [Required]
        public bool aceitaFinanciamento { get; set; }

        public decimal valor { get; set; }
        public bool publicar { get; set; }
        public bool vendido { get; set; }
        [Required]
        public bool destaque { get; set; }

        public string caminhofoto1 { get; set; }
        public string nomefoto1 { get; set; }
        public string extensaofoto1 { get; set; }
        public string caminhofoto2 { get; set; }
        public string nomefoto2 { get; set; }
        public string extensaofoto2 { get; set; }
        public string caminhofoto3 { get; set; }
        public string nomefoto3 { get; set; }
        public string extensaofoto3 { get; set; }
        public string caminhofoto4 { get; set; }
        public string nomefoto4 { get; set; }
        public string extensaofoto4 { get; set; }
        public string caminhofoto5 { get; set; }
        public string nomefoto5 { get; set; }
        public string extensaofoto5 { get; set; }

        public UsuarioEntity UsuarioPublicacao { get; set; }
        public DateTime datapublicacao { get; set; }

        public string descricao { get; set; }
        public DateTime dataInclusao { get; set; }
        public UsuarioEntity UsuarioInclusao { get; set; }
        public DateTime dataAtualizacao { get; set; }
        public UsuarioEntity UsuarioAtualizacao { get; set; }
    }
}
