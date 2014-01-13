using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.CredBox.Model.Entity
{
    public class ImovelEntity : IEntity
    {
        public int id { get; set; }
        public ImobiliariaEntity Imobiliaria { get; set; }
        public CategoriaEntity Categoria { get; set; }
        public TipoEntity Tipo { get; set; }
        public EstadoEntity Estado { get; set; }
        public CidadeEntity Cidade { get; set; }
        public string endereco { get; set; }
        public string bairro { get; set; }
        public int numero { get; set; }
        public string complemento { get; set; }
        public string cep { get; set; }
        public string codigoImobiliaria { get; set; }
        public int vagagaragem { get; set; }
        public int quantidadeSuite { get; set; }
        public int quantidadeQuarto { get; set; }
        public int areaTerreno { get; set; }
        public int areaConstruida { get; set; }
        public bool aceitaFinanciamento { get; set; }
        public decimal valor { get; set; }
        public bool publicar { get; set; }
        public bool vendido { get; set; }
        public bool destaque { get; set; }
        public string caminhoFotoDestaque { get; set; }
        public string nomeFotoDestaque { get; set; }
        public string extensaoFotoDestaque { get; set; }
        public string caminhoFotoPrincipal { get; set; }
        public string nomeFotoPrinciapl { get; set; }
        public string extensaoFotoPrincipal { get; set; }
        public string descricao { get; set; }
        public UsuarioEntity UsuarioPublicacao { get; set; }
        public DateTime dataInclusao { get; set; }
        public UsuarioEntity UsuarioInclusao { get; set; }
        public DateTime dataAtualizacao { get; set; }
        public UsuarioEntity UsuarioAtualizacao { get; set; }
    }
}
