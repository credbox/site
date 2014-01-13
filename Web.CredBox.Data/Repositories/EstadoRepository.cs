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
    public class EstadoRepository : GenericData, IEstado
    {
        public IList<EstadoEntity> GetAll()
        {
            var estados = new List<EstadoEntity>();
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_ESTADOGETALL";
                    command.Connection.Open();

                    command.Parameters.Clear();

                    try
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            estados.Add(new EstadoEntity
                            {
                                id = GetAsInt(reader, "id"),
                                nome = reader["nome"].ToString(),
                                sigla = reader["sigla"].ToString()

                            });
                        }


                        return estados;
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
