using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace Web.CredBox.Data
{
    /// <summary>
    /// Classe abstrata para controle da conexão com o banco e conversão de valores retornado em consultas
    /// </summary>
    public abstract class GenericData
    {
        /// <summary>
        /// Busca a conexão com o banco
        /// </summary>
        /// <returns>Retorna a conexão</returns>
        protected MySqlConnection GetConnection()
        {
            return new MySqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
        }

        /// <summary>
        /// Converte o valor para inteiro
        /// </summary>
        /// <param name="dr">Data Reader</param>
        /// <param name="campo">Nome do campo</param>
        /// <returns>Retorna o valor convertido em int no caso de sucesso. Caso não seja possível converter o valor para int, será retornado o valor zero.</returns>
        protected int GetAsInt(IDataReader dr, string campo)
        {
            int index = dr.GetOrdinal(campo);
            if (!dr.IsDBNull(index))
                return Convert.ToInt32(dr.GetValue(index));
            else
                return 0;
        }

        /// <summary>
        /// Converte o valor para long
        /// </summary>
        /// <param name="dr">Data Reader</param>
        /// <param name="campo">Nome do campo</param>
        /// <returns>Retorna o valor convertido em long no caso de sucesso. Caso não seja possível converter o valor para long, será retornado o valor zero.</returns>
        protected long GetAsLong(IDataReader dr, string campo)
        {
            int index = dr.GetOrdinal(campo);
            if (!dr.IsDBNull(index))
                return Convert.ToInt64(dr.GetValue(index));
            else
                return 0;
        }

        /// <summary>
        /// Converte o valor para booleano
        /// </summary>
        /// <param name="dr">Data Reader</param>
        /// <param name="campo">Nome do campo</param>
        /// <returns>Retorna o valor convertido em booleano no caso de sucesso. Caso não seja possível converter o valor boolean, será retornado o valor false.</returns>
        protected bool GetAsBoolean(IDataReader dr, string campo)
        {
            int index = dr.GetOrdinal(campo);
            if (!dr.IsDBNull(index))
                return Convert.ToBoolean(dr.GetValue(index));
            else
                return false;
        }
        /// <summary>
        /// Converte o valor para Guid(Unique identifier)
        /// </summary>
        /// <param name="dr">Data Reader</param>
        /// <param name="campo">Nome do campo</param>
        /// <returns>Retorna o valor convertido em Guid (Unique identifier) no caso de sucesso. Caso não seja possível converter o valor para Guid, será retornado um novo guid.</returns>
        protected Guid GetAsGuid(IDataReader dr, string campo)
        {
            int index = dr.GetOrdinal(campo);
            if (!dr.IsDBNull(index))
                return new Guid(dr.GetValue(index).ToString());
            else
                return new Guid();
        }

        /// <summary>
        /// Converte o valor para DateTime
        /// </summary>
        /// <param name="dr">Data Reader</param>
        /// <param name="campo">Nome do campo</param>
        /// <returns>Retorna o valor convertido em DateTime no caso de sucesso. Cason não seja possível converter o valor para DateTime, será retornado um DateTime.MinValue</returns>
        protected DateTime GetAsDateTime(IDataReader dr, string campo)
        {
            int index = dr.GetOrdinal(campo);
            if (!dr.IsDBNull(index))
                return dr.GetDateTime(index);
            else
                return DateTime.MinValue;
        }

        /// <summary>
        /// Converte o valor para Decimal
        /// </summary>
        /// <param name="dr">Data Reader</param>
        /// <param name="campo">Nome do campo</param>
        /// <returns>Retorna o valor convertido em Decimal no caso de sucesso. Caso não seja possível converter o valor para Decimal, será retornado o valor zero.</returns>
        protected decimal GetAsDecimal(IDataReader dr, string campo)
        {
            int index = dr.GetOrdinal(campo);
            if (!dr.IsDBNull(index))
                return dr.GetDecimal(index);
            else
                return 0;
        }

        /// <summary>
        /// Converte o valor para Float
        /// </summary>
        /// <param name="dr">Data Reader</param>
        /// <param name="campo">Nome do campo</param>
        /// <returns>Retorna o valor convertido em Float no caso de sucesso. Caso não seja possível converter o valor para Float, será retornado o valor zero.</returns>
        protected float GetAsFloat(IDataReader dr, string campo)
        {
            int index = dr.GetOrdinal(campo);
            if (!dr.IsDBNull(index))
                return dr.GetFloat(index);
            else
                return 0;
        }

        /// <summary>
        /// Converte o valor para Double
        /// </summary>
        /// <param name="dr">Data Reader</param>
        /// <param name="campo">Nome do campo</param>
        /// <returns>Retorna o valor convertido em Double no caso de sucesso. Caso não seja possível converter o valor para Decimal, será retornado o valor zero.</returns>
        protected double GetAsDouble(IDataReader dr, string campo)
        {
            int index = dr.GetOrdinal(campo);
            if (!dr.IsDBNull(index))
                return dr.GetDouble(index);
            else
                return 0;
        }
    }
}
