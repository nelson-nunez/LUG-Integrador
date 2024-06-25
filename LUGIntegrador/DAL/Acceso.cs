using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DAL
{
    public class Acceso
    {
        private SqlConnection _connection;
        private SqlTransaction _transaction;

        public Acceso(SqlConnection connection = null)
        {
            _connection = connection ?? new SqlConnection(ConfigurationManager.ConnectionStrings["MiCadenaDeConexion"].ToString());
        }

        #region TEST CONECTION

        public string TestConnection()
        {
            try
            {
                _connection.Open();
                return _connection.State == ConnectionState.Open ? "Conexión a la BD OK" : "No se pudo conectar a la BD";
            }
            catch (SqlException sqlEx)
            {
                return $"SQL Error: {sqlEx.Message}";
            }
            catch (Exception ex)
            {
                return $"Error General: {ex.Message}";
            }
            finally
            {
                _connection.Close();
            }
        }

        #endregion

        #region OPERACIONES SIMPLES

        public DataTable Leer(string query)
        {
            DataTable table = new DataTable();
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, _connection))
                {
                    adapter.Fill(table);
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                _connection.Close();
            }
            return table;
        }

        public bool LeerScalar(string query)
        {
            try
            {
                _connection.Open();
                using (SqlCommand cmd = new SqlCommand(query, _connection))
                {
                    cmd.CommandType = CommandType.Text;
                    int response = Convert.ToInt32(cmd.ExecuteScalar());
                    return response > 0;
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        public DataSet Leer2(string query)
        {
            DataSet dataset = new DataSet();
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, _connection))
                {
                    adapter.Fill(dataset);
                }
            }
            catch (SqlException ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw ex;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                throw ex;
            }
            finally
            {
                _connection.Close();
            }
            return dataset;
        }

        public bool Escribir(string query)
        {
            try
            {
                _connection.Open();
                _transaction = _connection.BeginTransaction();
                using (SqlCommand cmd = new SqlCommand(query, _connection, _transaction))
                {
                    cmd.CommandType = CommandType.Text;
                    int response = cmd.ExecuteNonQuery();
                    _transaction.Commit();
                    return true;
                }
            }
            catch (SqlException ex)
            {
                _transaction?.Rollback();
                Console.Error.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                _transaction?.Rollback();
                Console.Error.WriteLine(ex.Message);
                return false;
            }
            finally
            {
                _connection.Close();
            }
        }

        #endregion

        #region OPERACIONES CON LIST

        public DataTable Leer(string consulta, List<SqlParameter> parametros)
        {
            DataTable tabla = new DataTable();
            SqlDataAdapter adaptador;

            using (SqlCommand comando = new SqlCommand(consulta, _connection))
            {
                comando.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (SqlParameter parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.ParameterName, parametro.Value);
                    }
                }

                try
                {
                    adaptador = new SqlDataAdapter(comando);
                    adaptador.Fill(tabla);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return tabla;
        }

        public bool LeerScalar(string consulta, List<SqlParameter> parametros)
        {
            bool resultado = false;

            using (SqlCommand comando = new SqlCommand(consulta, _connection))
            {
                comando.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (SqlParameter parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.ParameterName, parametro.Value);
                    }
                }

                try
                {
                    _connection.Open();
                    int respuesta = Convert.ToInt32(comando.ExecuteScalar());
                    resultado = (respuesta > 0);
                }
                catch (SqlException ex)
                {
                    throw ex;
                }
                finally
                {
                    _connection.Close();
                }
            }

            return resultado;
        }

        public bool Escribir(string consulta, List<SqlParameter> parametros)
        {
            bool exito = false;
            using (SqlCommand comando = new SqlCommand(consulta, _connection))
            {
                comando.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                {
                    foreach (SqlParameter parametro in parametros)
                    {
                        comando.Parameters.AddWithValue(parametro.ParameterName, parametro.Value);
                    }
                }
                try
                {
                    _connection.Open();
                    _transaction = _connection.BeginTransaction();
                    comando.Transaction = _transaction;
                    comando.ExecuteNonQuery();
                    _transaction.Commit();
                    exito = true; // Si no hay excepciones, consideramos que fue exitoso
                }
                catch (SqlException ex)
                {
                    _transaction.Rollback();
                    throw ex;
                }
                catch (Exception ex)
                {
                    _transaction.Rollback();
                    throw ex;
                }
                finally
                {
                    _connection.Close();
                }
            }

            return exito;
        }


        #endregion

    }
}