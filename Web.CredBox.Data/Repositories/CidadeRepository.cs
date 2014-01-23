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
    public class CidadeRepository:GenericData, ICidade
    {
        public IList<CidadeEntity> GetByIdEstado(int id)
        {
            var cidades = new List<CidadeEntity>();
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_CIDADEGETBYIDESTADO";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_idestado", id));

                    try
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            cidades.Add(new CidadeEntity
                            {
                                id = GetAsInt(reader, "id"),
                                IdEstado = new EstadoEntity {id = GetAsInt(reader,"idestado")},
                                nome = reader["nome"].ToString()
                            });
                        }


                        return cidades;
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
