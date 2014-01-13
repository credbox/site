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
    public class CategoriaRepository : GenericData, ICategoria
    {
        public bool Add(CategoriaEntity categoria)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_CATEGORIAADD";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_nome", categoria.nome));
                    command.Parameters.Add(new MySqlParameter("p_idUsuarioInclusao", categoria.UsuarioInclusao.id));
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

        public bool Edit(CategoriaEntity categoria)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_CATEGORIAEDIT";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", categoria.id));
                    command.Parameters.Add(new MySqlParameter("p_nome", categoria.nome));

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

        public IList<CategoriaEntity> GetAll()
        {
            var categorias = new List<CategoriaEntity>();
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_CATEGORIAGETALL";
                    command.Connection.Open();

                    command.Parameters.Clear();

                    try
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            categorias.Add(new CategoriaEntity
                            {
                                id = GetAsInt(reader, "id"),
                                nome = reader["nome"].ToString(),
                                dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                UsuarioInclusao = new UsuarioEntity { id = GetAsInt(reader, "idUsuarioInclusao") },
                            });
                        }


                        return categorias;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public CategoriaEntity GetById(int id)
        {
            CategoriaEntity categoria = null;
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_CATEGORIAGETBYID";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", id));
                    try
                    {
                        var reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            categoria = new CategoriaEntity
                            {
                                id = GetAsInt(reader, "id"),
                                nome = reader["nome"].ToString(),
                                dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                UsuarioInclusao = new UsuarioEntity { id = GetAsInt(reader, "idUsuarioInclusao") },

                            };
                        }


                        return categoria;
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
