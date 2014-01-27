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
    public class UsuarioRepository : GenericData, IUsuario
    {
        public bool Add(UsuarioEntity usuario)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_USUARIOADD";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    if (usuario.imobiliaria)
                    {
                        if (usuario.Imobiliaria != null)
                            command.Parameters.Add(new MySqlParameter("p_idimobiliaria", usuario.Imobiliaria.id));
                        else
                            command.Parameters.Add(new MySqlParameter("p_idimobiliaria", DBNull.Value));
                    }
                    else
                    {
                        command.Parameters.Add(new MySqlParameter("p_idimobiliaria", DBNull.Value));
                    }

                    command.Parameters.Add(new MySqlParameter("p_nome", usuario.nome));

                    command.Parameters.Add(new MySqlParameter("p_email", usuario.email));
                    command.Parameters.Add(new MySqlParameter("p_login", usuario.login));
                    command.Parameters.Add(new MySqlParameter("p_senha", usuario.senha));
                    command.Parameters.Add(new MySqlParameter("p_emailnotificacao", usuario.emailNotificacao));
                    command.Parameters.Add(new MySqlParameter("p_imobiliaria", usuario.imobiliaria));
                    command.Parameters.Add(new MySqlParameter("p_ativo", usuario.ativo));
                    command.Parameters.Add(new MySqlParameter("p_idUsuarioInclusao", usuario.UsuarioInclusao.id));


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
        public bool Edit(UsuarioEntity usuario)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_USUARIOEDIT";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", usuario.id));
                    if (usuario.imobiliaria)
                    {
                        if (usuario.Imobiliaria != null)
                            command.Parameters.Add(new MySqlParameter("p_idimobiliaria", usuario.Imobiliaria.id));
                        else
                            command.Parameters.Add(new MySqlParameter("p_idimobiliaria", DBNull.Value));
                    }
                    else
                    {
                        command.Parameters.Add(new MySqlParameter("p_idimobiliaria", DBNull.Value));
                    }

                    command.Parameters.Add(new MySqlParameter("p_nome", usuario.nome));

                    command.Parameters.Add(new MySqlParameter("p_email", usuario.email));
                    command.Parameters.Add(new MySqlParameter("p_login", usuario.login));
                    command.Parameters.Add(new MySqlParameter("p_senha", usuario.senha));
                    command.Parameters.Add(new MySqlParameter("p_emailnotificacao", usuario.emailNotificacao));
                    command.Parameters.Add(new MySqlParameter("p_imobiliaria", usuario.imobiliaria));
                    command.Parameters.Add(new MySqlParameter("p_ativo", usuario.ativo));
                    command.Parameters.Add(new MySqlParameter("p_idUsuarioInclusao", usuario.UsuarioInclusao.id));

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
        public IList<UsuarioEntity> GetAllByStatus(string nome, string email, string login, int idimobiliaria, bool ativo)
        {
            var usuarios = new List<UsuarioEntity>();
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_USUARIOGETALL";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_nome", nome));
                    command.Parameters.Add(new MySqlParameter("p_email", email));
                    command.Parameters.Add(new MySqlParameter("p_login", login));
                    command.Parameters.Add(new MySqlParameter("p_idimobiliaria", idimobiliaria));
                    command.Parameters.Add(new MySqlParameter("p_ativo", ativo));

                    try
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            usuarios.Add(new UsuarioEntity
                            {
                                id = GetAsInt(reader, "id"),
                                Imobiliaria = new ImobiliariaEntity { nome = reader["nomeImobiliaria"].ToString() },
                                nome = reader["nomeUsuario"].ToString(),
                                email = reader["email"].ToString(),
                                login = reader["login"].ToString(),
                                imobiliaria = GetAsBoolean(reader, "imobiliaria"),
                                emailNotificacao = GetAsBoolean(reader, "emailnotificacao"),
                                ativo = GetAsBoolean(reader, "ativo"),
                                dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                UsuarioInclusao = new UsuarioEntity { nome = reader["nomeInclusao"].ToString() },
                            });
                        }
                        return usuarios;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public UsuarioEntity GetById(int id)
        {
            UsuarioEntity usuario = null;
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
                        var reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            usuario = new UsuarioEntity
                            {
                                id = GetAsInt(reader, "id"),
                                Imobiliaria = new ImobiliariaEntity { id = GetAsInt(reader, "nomeImobiliaria") },
                                nome = reader["nome"].ToString(),
                                email = reader["email"].ToString(),
                                login = reader["login"].ToString(),
                                senha = reader["senha"].ToString(),
                                imobiliaria = GetAsBoolean(reader, "imobiliaria"),
                                emailNotificacao = GetAsBoolean(reader, "emailnotificacao"),
                                ativo = GetAsBoolean(reader, "ativo"),
                                dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                UsuarioInclusao = new UsuarioEntity { id = GetAsInt(reader, "idUsuarioInclusao") },

                            };
                        }


                        return usuario;
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
