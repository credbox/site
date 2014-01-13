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
    public class FaleConoscoRepository : GenericData, IFaleConosco
    {
        public bool Add(FaleConoscoEntity faleConosco)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_FALECONOSCOADD";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_idimovel", faleConosco.Imovel.id));
                    command.Parameters.Add(new MySqlParameter("p_idassunto", faleConosco.Assunto.id));
                    command.Parameters.Add(new MySqlParameter("p_nome", faleConosco.nome));
                    command.Parameters.Add(new MySqlParameter("p_email", faleConosco.email));
                    command.Parameters.Add(new MySqlParameter("p_telefone", faleConosco.telefone));
                    command.Parameters.Add(new MySqlParameter("p_celular", faleConosco.celular));
                    command.Parameters.Add(new MySqlParameter("p_descricao", faleConosco.descricao));

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

        public bool Edit(FaleConoscoEntity faleConosco)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_FALECONOSCOEDIT";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", faleConosco.id));
                    command.Parameters.Add(new MySqlParameter("p_ativo", faleConosco.ativo));

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

        public IList<FaleConoscoEntity> GetAllByStatus(bool ativo)
        {
            var faleConoscos = new List<FaleConoscoEntity>();
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_FALECONOSCOGETALL";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_ativo", ativo));


                    try
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            faleConoscos.Add(new FaleConoscoEntity
                            {
                                id = GetAsInt(reader, "id"),
                                Imovel = new ImovelEntity { id = GetAsInt(reader, "idimovel") },
                                Assunto = new AssuntoEntity { nome = reader["assunto"].ToString() },
                                nome = reader["nome"].ToString(),
                                email = reader["email"].ToString(),
                                telefone = reader["telefone"].ToString(),
                                celular = reader["celular"].ToString(),
                                descricao = reader["descricao"].ToString(),
                                ativo = GetAsBoolean(reader, "ativo"),
                                dataInclusao = GetAsDateTime(reader, "dataInclusao")
                            });
                        }


                        return faleConoscos;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public FaleConoscoEntity GetById(int id)
        {
            FaleConoscoEntity faleConosco = null;
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_FALECONOSCOGETBYID";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", id));
                    try
                    {
                        var reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            faleConosco = new FaleConoscoEntity
                            {
                                id = GetAsInt(reader, "id"),
                                Imovel = new ImovelEntity { id = GetAsInt(reader, "idimovel") },
                                Assunto = new AssuntoEntity { id = GetAsInt(reader, "assunto") },
                                nome = reader["nome"].ToString(),
                                email = reader["email"].ToString(),
                                telefone = reader["telefone"].ToString(),
                                celular = reader["celular"].ToString(),
                                descricao = reader["descricao"].ToString(),
                                ativo = GetAsBoolean(reader, "ativo"),
                                dataInclusao = GetAsDateTime(reader, "dataInclusao")
                            };
                        }


                        return faleConosco;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }
    }
}

