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
    public class TipoRepository : GenericData, ITipo
    {
        public bool Add(TipoEntity tipo)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_TIPOADD";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_nome", tipo.nome));
                    command.Parameters.Add(new MySqlParameter("p_idUsuarioInclusao", tipo.UsuarioInclusao.id));
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

        public bool Edit(TipoEntity tipo)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_TIPOEDIT";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", tipo.id));
                    command.Parameters.Add(new MySqlParameter("p_nome", tipo.nome));

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

        public IList<TipoEntity> GetAll()
        {
            var tipos = new List<TipoEntity>();
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_TIPOGETALL";
                    command.Connection.Open();

                    command.Parameters.Clear();

                    try
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            tipos.Add(new TipoEntity
                            {
                                id = GetAsInt(reader, "id"),
                                nome = reader["nome"].ToString(),
                                dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                UsuarioInclusao = new UsuarioEntity { id = GetAsInt(reader, "idUsuarioInclusao") },
                            });
                        }


                        return tipos;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public TipoEntity GetById(int id)
        {
            TipoEntity tipo = null;
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_TIPOGETBYID";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", id));
                    try
                    {
                        var reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            tipo = new TipoEntity
                            {
                                id = GetAsInt(reader, "id"),
                                nome = reader["nome"].ToString(),
                                dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                UsuarioInclusao = new UsuarioEntity { id = GetAsInt(reader, "idUsuarioInclusao") },

                            };
                        }
                        return tipo;
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
