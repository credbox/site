using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.CredBox.Data.Provider;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Data.Repositories
{
    public class ImovelRepository : GenericData, IImovel
    {
        public int Add(ImovelEntity imovel)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_IMOVELADD";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_idimobiliaria", imovel.Imobiliaria.id));
                    command.Parameters.Add(new MySqlParameter("p_nome", imovel.nome));
                    command.Parameters.Add(new MySqlParameter("p_idcategoria", imovel.Categoria.id));
                    command.Parameters.Add(new MySqlParameter("p_idtipo", imovel.Tipo.id));
                    command.Parameters.Add(new MySqlParameter("p_idestado", imovel.Estado.id));
                    command.Parameters.Add(new MySqlParameter("p_idcidade", imovel.Cidade.id));
                    command.Parameters.Add(new MySqlParameter("p_bairro", imovel.bairro));
                    command.Parameters.Add(new MySqlParameter("p_endereco", imovel.endereco));
                    command.Parameters.Add(new MySqlParameter("p_numero", imovel.numero));
                    command.Parameters.Add(new MySqlParameter("p_complemento", imovel.complemento));
                    command.Parameters.Add(new MySqlParameter("p_cep", imovel.cep));
                    command.Parameters.Add(new MySqlParameter("p_codigoimobiliaria", imovel.codigoImobiliaria));
                    command.Parameters.Add(new MySqlParameter("p_vagagaragem", imovel.vagagaragem));
                    command.Parameters.Add(new MySqlParameter("p_quantidadesuite", imovel.quantidadeSuite));
                    command.Parameters.Add(new MySqlParameter("p_quantidadequarto", imovel.quantidadeQuarto));
                    command.Parameters.Add(new MySqlParameter("p_areaterreno", imovel.areaTerreno));
                    command.Parameters.Add(new MySqlParameter("p_areaconstruida", imovel.areaConstruida));
                    command.Parameters.Add(new MySqlParameter("p_aceitafinanciamento", imovel.aceitaFinanciamento));
                    command.Parameters.Add(new MySqlParameter("p_valor", imovel.valor));
                    command.Parameters.Add(new MySqlParameter("p_descricao", imovel.descricao));
                    command.Parameters.Add(new MySqlParameter("p_idUsuarioInclusao", imovel.UsuarioInclusao.id));
                    try
                    {
                        var value = int.Parse(command.ExecuteScalar().ToString());
                        return value;

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public bool AddImages(ImovelEntity imovel)
        {

            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_IMOVELADDIMAGES";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", imovel.id));

                    command.Parameters.Add(new MySqlParameter("p_publicar", false));

                    #region Foto 1

                    if (!string.IsNullOrEmpty(imovel.caminhofoto1))
                        command.Parameters.Add(new MySqlParameter("p_caminhofoto1", imovel.caminhofoto1));
                    else
                        command.Parameters.Add(new MySqlParameter("p_caminhofoto1", DBNull.Value));

                    if (!string.IsNullOrEmpty(imovel.nomefoto1))
                        command.Parameters.Add(new MySqlParameter("p_nomefoto1", imovel.nomefoto1));
                    else
                        command.Parameters.Add(new MySqlParameter("p_nomefoto1", DBNull.Value));

                    if (!string.IsNullOrEmpty(imovel.extensaofoto1))
                        command.Parameters.Add(new MySqlParameter("p_extensaofoto1", imovel.extensaofoto1));
                    else
                        command.Parameters.Add(new MySqlParameter("p_extensaofoto1", DBNull.Value));

                    #endregion

                    #region Foto 2
                    if (!string.IsNullOrEmpty(imovel.caminhofoto2))
                        command.Parameters.Add(new MySqlParameter("p_caminhofoto2", imovel.caminhofoto2));
                    else
                        command.Parameters.Add(new MySqlParameter("p_caminhofoto2", DBNull.Value));

                    if (!string.IsNullOrEmpty(imovel.nomefoto2))
                        command.Parameters.Add(new MySqlParameter("p_nomefoto2", imovel.nomefoto2));
                    else
                        command.Parameters.Add(new MySqlParameter("p_nomefoto2", DBNull.Value));

                    if (!string.IsNullOrEmpty(imovel.extensaofoto2))
                        command.Parameters.Add(new MySqlParameter("p_extensaofoto2", imovel.extensaofoto2));
                    else
                        command.Parameters.Add(new MySqlParameter("p_extensaofoto2", DBNull.Value));
                    #endregion

                    #region Foto 3
                    if (!string.IsNullOrEmpty(imovel.caminhofoto3))
                        command.Parameters.Add(new MySqlParameter("p_caminhofoto3", imovel.caminhofoto3));
                    else
                        command.Parameters.Add(new MySqlParameter("p_caminhofoto3", DBNull.Value));

                    if (!string.IsNullOrEmpty(imovel.nomefoto3))
                        command.Parameters.Add(new MySqlParameter("p_nomefoto3", imovel.nomefoto3));
                    else
                        command.Parameters.Add(new MySqlParameter("p_nomefoto3", DBNull.Value));

                    if (!string.IsNullOrEmpty(imovel.extensaofoto3))
                        command.Parameters.Add(new MySqlParameter("p_extensaofoto3", imovel.extensaofoto3));
                    else
                        command.Parameters.Add(new MySqlParameter("p_extensaofoto3", DBNull.Value));

                    #endregion

                    #region Foto 4

                    if (!string.IsNullOrEmpty(imovel.caminhofoto4))
                        command.Parameters.Add(new MySqlParameter("p_caminhofoto4", imovel.caminhofoto4));
                    else
                        command.Parameters.Add(new MySqlParameter("p_caminhofoto4", DBNull.Value));

                    if (!string.IsNullOrEmpty(imovel.nomefoto4))
                        command.Parameters.Add(new MySqlParameter("p_nomefoto4", imovel.nomefoto4));
                    else
                        command.Parameters.Add(new MySqlParameter("p_nomefoto4", DBNull.Value));

                    if (!string.IsNullOrEmpty(imovel.extensaofoto4))
                        command.Parameters.Add(new MySqlParameter("p_extensaofoto4", imovel.extensaofoto4));
                    else
                        command.Parameters.Add(new MySqlParameter("p_extensaofoto4", DBNull.Value));

                    #endregion

                    #region Foto 5
                    if (!string.IsNullOrEmpty(imovel.caminhofoto5))
                        command.Parameters.Add(new MySqlParameter("p_caminhofoto5", imovel.caminhofoto5));
                    else
                        command.Parameters.Add(new MySqlParameter("p_caminhofoto5", DBNull.Value));

                    if (!string.IsNullOrEmpty(imovel.nomefoto5))
                        command.Parameters.Add(new MySqlParameter("p_nomefoto5", imovel.nomefoto5));
                    else
                        command.Parameters.Add(new MySqlParameter("p_nomefoto5", DBNull.Value));

                    if (!string.IsNullOrEmpty(imovel.extensaofoto5))
                        command.Parameters.Add(new MySqlParameter("p_extensaofoto5", imovel.extensaofoto5));
                    else
                        command.Parameters.Add(new MySqlParameter("p_extensaofoto5", DBNull.Value));

                    #endregion

                    command.Parameters.Add(new MySqlParameter("p_idusuarioAtualizacao", imovel.UsuarioAtualizacao.id));
                    try
                    {
                        var value = command.ExecuteNonQuery();
                        if (value > 0)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

        }

        public bool Edit(ImovelEntity imovel)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_IMOVELEDIT";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", imovel.id));
                    command.Parameters.Add(new MySqlParameter("p_idimobiliaria", imovel.Imobiliaria.id));
                    command.Parameters.Add(new MySqlParameter("p_nome", imovel.nome));
                    command.Parameters.Add(new MySqlParameter("p_idcategoria", imovel.Categoria.id));
                    command.Parameters.Add(new MySqlParameter("p_idtipo", imovel.Tipo.id));
                    command.Parameters.Add(new MySqlParameter("p_idestado", imovel.Estado.id));
                    command.Parameters.Add(new MySqlParameter("p_idcidade", imovel.Cidade.id));
                    command.Parameters.Add(new MySqlParameter("p_bairro", imovel.bairro));
                    command.Parameters.Add(new MySqlParameter("p_endereco", imovel.endereco));
                    command.Parameters.Add(new MySqlParameter("p_numero", imovel.numero));
                    command.Parameters.Add(new MySqlParameter("p_complemento", imovel.complemento));
                    command.Parameters.Add(new MySqlParameter("p_cep", imovel.cep));
                    command.Parameters.Add(new MySqlParameter("p_codigoimobiliaria", imovel.codigoImobiliaria));
                    command.Parameters.Add(new MySqlParameter("p_vagagaragem", imovel.vagagaragem));
                    command.Parameters.Add(new MySqlParameter("p_quantidadesuite", imovel.quantidadeSuite));
                    command.Parameters.Add(new MySqlParameter("p_quantidadequarto", imovel.quantidadeQuarto));
                    command.Parameters.Add(new MySqlParameter("p_areaterreno", imovel.areaTerreno));
                    command.Parameters.Add(new MySqlParameter("p_areaconstruida", imovel.areaConstruida));
                    command.Parameters.Add(new MySqlParameter("p_aceitafinanciamento", imovel.aceitaFinanciamento));
                    command.Parameters.Add(new MySqlParameter("p_valor", imovel.valor));
                    command.Parameters.Add(new MySqlParameter("p_publicar", imovel.publicar));
                    command.Parameters.Add(new MySqlParameter("p_destaque", imovel.destaque));
                    //command.Parameters.Add(new MySqlParameter("p_caminhofotodestaque", imovel.caminhoFotoDestaque));
                    //command.Parameters.Add(new MySqlParameter("p_nomefotodestaque", imovel.nomeFotoDestaque));
                    //command.Parameters.Add(new MySqlParameter("p_extensaofotodestaque", imovel.extensaoFotoDestaque));
                    //command.Parameters.Add(new MySqlParameter("p_caminhofotoprincipal", imovel.caminhoFotoPrincipal));
                    //command.Parameters.Add(new MySqlParameter("p_nomefotoprincipal", imovel.nomeFotoPrinciapl));
                    //command.Parameters.Add(new MySqlParameter("p_extensaofotoprincipal", imovel.extensaoFotoPrincipal));
                    command.Parameters.Add(new MySqlParameter("p_descricao", imovel.descricao));
                    command.Parameters.Add(new MySqlParameter("p_idUsuarioInclusao", imovel.UsuarioInclusao.id));

                    try
                    {
                        var value = bool.Parse(command.ExecuteNonQuery().ToString());

                        if (value)
                            return true;
                        else
                            return false;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public IList<ImovelEntity> GetAll(int idimobiliaria, bool publicar, bool vendido, string nome, string codigoimobiliaria, int idCategoria, int idTipo, int idEstado, int idCidade)
        {
            var imoveis = new List<ImovelEntity>();
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_IMOVELGETALL";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    if (idimobiliaria > 0)
                        command.Parameters.Add(new MySqlParameter("p_idimobiliaria", idimobiliaria));
                    else
                        command.Parameters.Add(new MySqlParameter("p_idimobiliaria", DBNull.Value));

                    command.Parameters.Add(new MySqlParameter("p_publicar", publicar));
                    command.Parameters.Add(new MySqlParameter("p_vendido", vendido));

                    if (!string.IsNullOrEmpty(nome))
                        command.Parameters.Add(new MySqlParameter("p_nome", nome));
                    else
                        command.Parameters.Add(new MySqlParameter("p_nome", DBNull.Value));

                    if (!string.IsNullOrEmpty(codigoimobiliaria))
                        command.Parameters.Add(new MySqlParameter("p_codigoimobiliaria", codigoimobiliaria));
                    else
                        command.Parameters.Add(new MySqlParameter("p_codigoimobiliaria", DBNull.Value));

                    if (idCategoria > 0)
                        command.Parameters.Add(new MySqlParameter("p_idCategoria", idCategoria));
                    else
                        command.Parameters.Add(new MySqlParameter("p_idCategoria", DBNull.Value));

                    if (idTipo > 0)
                        command.Parameters.Add(new MySqlParameter("p_idTipo", idTipo));
                    else
                        command.Parameters.Add(new MySqlParameter("p_idTipo", DBNull.Value));

                    if (idEstado > 0)
                        command.Parameters.Add(new MySqlParameter("p_idEstado", idEstado));
                    else
                        command.Parameters.Add(new MySqlParameter("p_idEstado", DBNull.Value));

                    if (idCidade > 0)
                        command.Parameters.Add(new MySqlParameter("p_idCidade", idCidade));
                    else
                        command.Parameters.Add(new MySqlParameter("p_idCidade", DBNull.Value));

                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                imoveis.Add(new ImovelEntity
                                {
                                    id = GetAsInt(reader, "id"),
                                    Imobiliaria = new ImobiliariaEntity { nome = reader["nomeImobiliaria"].ToString() },
                                    nome = reader["nome"].ToString(),
                                    Categoria = new CategoriaEntity { nome = reader["nomeCategoria"].ToString() },
                                    Tipo = new TipoEntity { nome = reader["nomeTipo"].ToString() },
                                    Estado = new EstadoEntity { sigla = reader["sigla"].ToString() },
                                    Cidade = new CidadeEntity { nome = reader["nomeCidade"].ToString() },
                                    bairro = reader["bairro"].ToString(),
                                    endereco = reader["endereco"].ToString(),
                                    numero = GetAsInt(reader, "numero"),
                                    complemento = reader["complemento"].ToString(),
                                    cep = reader["cep"].ToString(),
                                    codigoImobiliaria = reader["codigoimobiliaria"].ToString(),
                                    vagagaragem = GetAsInt(reader, "vagagaragem"),
                                    quantidadeSuite = GetAsInt(reader, "quantidadesuite"),
                                    quantidadeQuarto = GetAsInt(reader, "quantidadequarto"),
                                    areaTerreno = GetAsDecimal(reader, "areaterreno"),
                                    areaConstruida = GetAsDecimal(reader, "areaconstruida"),
                                    aceitaFinanciamento = GetAsBoolean(reader, "aceitafinanciamento"),
                                    valor = GetAsDecimal(reader, "valor"),
                                    publicar = GetAsBoolean(reader, "publicar"),
                                    vendido = GetAsBoolean(reader, "vendido"),
                                    destaque = GetAsBoolean(reader, "destaque"),
                                    caminhofoto1 = reader["caminhofoto1"].ToString(),
                                    nomefoto1 = reader["nomefoto1"].ToString(),
                                    extensaofoto1 = reader["extensaofoto1"].ToString(),
                                    caminhofoto2 = reader["caminhofoto2"].ToString(),
                                    nomefoto2 = reader["nomefoto2"].ToString(),
                                    extensaofoto2 = reader["extensaofoto2"].ToString(),
                                    caminhofoto3 = reader["caminhofoto3"].ToString(),
                                    nomefoto3 = reader["nomefoto3"].ToString(),
                                    extensaofoto3 = reader["extensaofoto3"].ToString(),
                                    caminhofoto4 = reader["caminhofoto4"].ToString(),
                                    nomefoto4 = reader["nomefoto4"].ToString(),
                                    extensaofoto4 = reader["extensaofoto4"].ToString(),
                                    caminhofoto5 = reader["caminhofoto5"].ToString(),
                                    nomefoto5 = reader["nomefoto5"].ToString(),
                                    extensaofoto5 = reader["extensaofoto5"].ToString(),
                                    descricao = reader["descricao"].ToString(),
                                    UsuarioPublicacao = new UsuarioEntity { nome = reader["nomepublicacao"].ToString() },
                                    UsuarioInclusao = new UsuarioEntity { nome = reader["nomeinclusao"].ToString() },
                                    dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                    UsuarioAtualizacao = new UsuarioEntity { nome = reader["nomeatualizacao"].ToString() },
                                    dataAtualizacao = GetAsDateTime(reader, "dataatualizacao"),
                                    datapublicacao = GetAsDateTime(reader, "datapublicacao")

                                });
                            }
                        }

                        return imoveis;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public ImovelEntity GetById(int id)
        {
            ImovelEntity imovel = null;
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_IMOVELGETBYID";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", id));
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                imovel = new ImovelEntity
                                {

                                    id = GetAsInt(reader, "id"),
                                    Imobiliaria = new ImobiliariaEntity { id = GetAsInt(reader, "idimobiliaria") },
                                    nome = reader["nome"].ToString(),
                                    Categoria = new CategoriaEntity { id = GetAsInt(reader, "idcategoria") },
                                    Tipo = new TipoEntity { id = GetAsInt(reader, "idtipo") },
                                    Estado = new EstadoEntity { id = GetAsInt(reader, "idestado") },
                                    Cidade = new CidadeEntity { id = GetAsInt(reader, "idcidade") },
                                    bairro = reader["bairro"].ToString(),
                                    endereco = reader["endereco"].ToString(),
                                    numero = GetAsInt(reader, "numero"),
                                    complemento = reader["complemento"].ToString(),
                                    cep = reader["cep"].ToString(),
                                    codigoImobiliaria = reader["codigoimobiliaria"].ToString(),
                                    vagagaragem = GetAsInt(reader, "vagagaragem"),
                                    quantidadeSuite = GetAsInt(reader, "quantidadesuite"),
                                    quantidadeQuarto = GetAsInt(reader, "quantidadequarto"),
                                    areaTerreno = GetAsDecimal(reader, "areaterreno"),
                                    areaConstruida = GetAsDecimal(reader, "areaconstruida"),
                                    aceitaFinanciamento = GetAsBoolean(reader, "aceitafinanciamento"),
                                    valor = GetAsDecimal(reader, "valor"),
                                    publicar = GetAsBoolean(reader, "publicar"),
                                    vendido = GetAsBoolean(reader, "vendido"),
                                    destaque = GetAsBoolean(reader, "destaque"),
                                    //caminhoFotoDestaque = reader["caminhofotodestaque"].ToString(),
                                    //nomeFotoDestaque = reader["nomefotodestaque"].ToString(),
                                    //extensaoFotoDestaque = reader["extensaofotodestaque"].ToString(),
                                    //caminhoFotoPrincipal = reader["caminhofotoprincipal"].ToString(),
                                    //nomeFotoPrinciapl = reader["nomefotoprincipal"].ToString(),
                                    //extensaoFotoPrincipal = reader["extensaofotoprincipal"].ToString(),
                                    descricao = reader["descricao"].ToString(),
                                    UsuarioPublicacao = new UsuarioEntity { id = GetAsInt(reader, "idusuarioinclusao") },
                                    UsuarioInclusao = new UsuarioEntity { id = GetAsInt(reader, "idusuariopublicacao") },
                                    UsuarioAtualizacao = new UsuarioEntity { id = GetAsInt(reader, "idusuarioatualizacao") },
                                    dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                    dataAtualizacao = GetAsDateTime(reader, "dataatualizacao")

                                };
                            }
                        }
                        return imovel;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }


        public IList<ImovelEntity> GetAllDestaque()
        {
            throw new NotImplementedException();
        }
    }
}
