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
    public class AssuntoRepository : GenericData, IAssunto
    {
        public bool Add(AssuntoEntity assunto)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_ASSUNTOADD";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_nome", assunto.nome));
                    command.Parameters.Add(new MySqlParameter("p_idUsuarioInclusao", assunto.UsuarioInclusao.id));
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

        public bool Edit(AssuntoEntity assunto)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_ASSUNTOEDIT";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", assunto.id));
                    command.Parameters.Add(new MySqlParameter("p_nome", assunto.nome));

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

        public IList<AssuntoEntity> GetAll(string nome)
        {
            var assuntos = new List<AssuntoEntity>();
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_ASSUNTOGETALL";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_nome", nome));

                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                assuntos.Add(new AssuntoEntity
                                {
                                    id = GetAsInt(reader, "id"),
                                    nome = reader["nome"].ToString(),
                                    dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                    UsuarioInclusao = new UsuarioEntity { nome = reader["nomeUsuario"].ToString() },
                                });
                            }
                        }


                        return assuntos;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public AssuntoEntity GetById(int id)
        {
            AssuntoEntity assunto = null;
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_ASSUNTOGETBYID";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", id));
                    try
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                assunto = new AssuntoEntity
                                {
                                    id = GetAsInt(reader, "id"),
                                    nome = reader["nome"].ToString(),
                                    dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                    UsuarioInclusao = new UsuarioEntity { id = GetAsInt(reader, "idUsuarioInclusao") },

                                };
                            }
                        }


                        return assunto;
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
