﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.CredBox.Data.Provider;
using Web.CredBox.Model.Entity;

namespace Web.CredBox.Data.Repositories
{
    public class ImobiliariaRepository : GenericData, IImobiliaria
    {
        public bool Add(ImobiliariaEntity imobiliaria)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_IMOBILIARIAADD";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_idestado", imobiliaria.Estado.id));
                    command.Parameters.Add(new MySqlParameter("p_idcidade", imobiliaria.Cidade.id));
                    command.Parameters.Add(new MySqlParameter("p_nome", imobiliaria.nome));
                    command.Parameters.Add(new MySqlParameter("p_endereco", imobiliaria.endereco));
                    command.Parameters.Add(new MySqlParameter("p_numero", imobiliaria.numero));
                    command.Parameters.Add(new MySqlParameter("p_cep", imobiliaria.cep));
                    command.Parameters.Add(new MySqlParameter("p_bairro", imobiliaria.bairro));
                    command.Parameters.Add(new MySqlParameter("p_contato", imobiliaria.contato));
                    command.Parameters.Add(new MySqlParameter("p_telefonecontato", imobiliaria.telefoneContato));
                    command.Parameters.Add(new MySqlParameter("p_celularcontato", imobiliaria.celularContato));
                    command.Parameters.Add(new MySqlParameter("p_emailcontato", imobiliaria.emailContato));
                    command.Parameters.Add(new MySqlParameter("p_complemento", imobiliaria.complemento));
                    command.Parameters.Add(new MySqlParameter("p_idUsuarioInclusao", imobiliaria.UsuarioInclusao.id));

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

        public bool Edit(ImobiliariaEntity imobiliaria)
        {
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_IMOBILIARIAEDIT";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_id", imobiliaria.id));
                    command.Parameters.Add(new MySqlParameter("p_idestado", imobiliaria.Estado.id));
                    command.Parameters.Add(new MySqlParameter("p_idcidade", imobiliaria.Cidade.id));
                    command.Parameters.Add(new MySqlParameter("p_nome", imobiliaria.nome));
                    command.Parameters.Add(new MySqlParameter("p_endereco", imobiliaria.endereco));
                    command.Parameters.Add(new MySqlParameter("p_numero", imobiliaria.numero));
                    command.Parameters.Add(new MySqlParameter("p_cep", imobiliaria.cep));
                    command.Parameters.Add(new MySqlParameter("p_bairro", imobiliaria.bairro));
                    command.Parameters.Add(new MySqlParameter("p_contato", imobiliaria.contato));
                    command.Parameters.Add(new MySqlParameter("p_telefonecontato", imobiliaria.telefoneContato));
                    command.Parameters.Add(new MySqlParameter("p_celularcontato", imobiliaria.celularContato));
                    command.Parameters.Add(new MySqlParameter("p_emailcontato", imobiliaria.emailContato));
                    command.Parameters.Add(new MySqlParameter("p_complemento", imobiliaria.complemento));
                    command.Parameters.Add(new MySqlParameter("p_ativo", imobiliaria.ativo));
                    command.Parameters.Add(new MySqlParameter("p_idUsuarioInclusao", imobiliaria.UsuarioInclusao.id));

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

        public IList<ImobiliariaEntity> GetAllByStatus(bool ativo)
        {
            var imobiliarias = new List<ImobiliariaEntity>();
            using (var connection = base.GetConnection())
            {
                using (var command = new MySqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.CommandText = "JP_IMOBILIARIAGETALL";
                    command.Connection.Open();

                    command.Parameters.Clear();
                    command.Parameters.Add(new MySqlParameter("p_ativo", ativo));

                    try
                    {
                        var reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            imobiliarias.Add(new ImobiliariaEntity
                            {
                                id = GetAsInt(reader, "id"),
                                Estado = new EstadoEntity { id = GetAsInt(reader, "idEstado") },
                                Cidade = new CidadeEntity { id = GetAsInt(reader, "idCidade") },
                                nome = reader["nome"].ToString(),
                                endereco = reader["endereco"].ToString(),
                                numero = GetAsInt(reader, "numero"),
                                cep = reader["cep"].ToString(),
                                bairro = reader["bairro"].ToString(),
                                complemento = reader["complemento"].ToString(),
                                contato = reader["contato"].ToString(),
                                telefoneContato = reader["telefoneContato"].ToString(),
                                celularContato = reader["celularContato"].ToString(),
                                emailContato = reader["emailContato"].ToString(),
                                ativo = GetAsBoolean(reader, "ativo"),
                                dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                UsuarioInclusao = new UsuarioEntity { id = GetAsInt(reader, "idUsuarioInclusao") },
                            });
                        }


                        return imobiliarias;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        public ImobiliariaEntity GetById(int id)
        {
            ImobiliariaEntity imobiliaria = null;
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
                            imobiliaria = new ImobiliariaEntity
                            {
                                id = GetAsInt(reader, "id"),
                                Estado = new EstadoEntity { id = GetAsInt(reader, "idEstado") },
                                Cidade = new CidadeEntity { id = GetAsInt(reader, "idCidade") },
                                nome = reader["nome"].ToString(),
                                endereco = reader["endereco"].ToString(),
                                numero = GetAsInt(reader, "numero"),
                                cep = reader["cep"].ToString(),
                                bairro = reader["bairro"].ToString(),
                                complemento = reader["complemento"].ToString(),
                                contato = reader["contato"].ToString(),
                                telefoneContato = reader["telefoneContato"].ToString(),
                                celularContato = reader["celularContato"].ToString(),
                                emailContato = reader["emailContato"].ToString(),
                                ativo = GetAsBoolean(reader, "ativo"),
                                dataInclusao = GetAsDateTime(reader, "dataInclusao"),
                                UsuarioInclusao = new UsuarioEntity { id = GetAsInt(reader, "idUsuarioInclusao") },

                            };
                        }


                        return imobiliaria;
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

