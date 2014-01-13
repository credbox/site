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
    public class ImovelRepository:GenericData, IImovel
    {
        public bool Add(ImovelEntity imovel)
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
                    command.Parameters.Add(new MySqlParameter("p_caminhofotodestaque", imovel.caminhoFotoDestaque));
                    command.Parameters.Add(new MySqlParameter("p_nomefotodestaque", imovel.nomeFotoDestaque));
                    command.Parameters.Add(new MySqlParameter("p_extensaofotodestaque", imovel.extensaoFotoDestaque));
                    command.Parameters.Add(new MySqlParameter("p_caminhofotoprincipal", imovel.caminhoFotoPrincipal));
                    command.Parameters.Add(new MySqlParameter("p_nomefotoprincipal", imovel.nomeFotoPrinciapl));
                    command.Parameters.Add(new MySqlParameter("p_extensaofotoprincipal", imovel.extensaoFotoPrincipal));
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
                    command.Parameters.Add(new MySqlParameter("p_caminhofotodestaque", imovel.caminhoFotoDestaque));
                    command.Parameters.Add(new MySqlParameter("p_nomefotodestaque", imovel.nomeFotoDestaque));
                    command.Parameters.Add(new MySqlParameter("p_extensaofotodestaque", imovel.extensaoFotoDestaque));
                    command.Parameters.Add(new MySqlParameter("p_caminhofotoprincipal", imovel.caminhoFotoPrincipal));
                    command.Parameters.Add(new MySqlParameter("p_nomefotoprincipal", imovel.nomeFotoPrinciapl));
                    command.Parameters.Add(new MySqlParameter("p_extensaofotoprincipal", imovel.extensaoFotoPrincipal));
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

        public IList<ImovelEntity> GetAll()
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

                    try
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            imoveis.Add(new ImovelEntity
                            {
                                id = GetAsInt(reader, "id"),
                                //nome = reader["nome"].ToString(),
                                dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                UsuarioInclusao = new UsuarioEntity { id = GetAsInt(reader, "idUsuarioInclusao") },
                            });
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
                        var reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            imovel = new ImovelEntity
                            {
                                id = GetAsInt(reader, "id"),
                                //nome = reader["nome"].ToString(),
                                dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                UsuarioInclusao = new UsuarioEntity { id = GetAsInt(reader, "idUsuarioInclusao") },

                            };
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
