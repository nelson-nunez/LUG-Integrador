using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Seguridad;

namespace MPP
{
    public class MPPPersona
    {
        private Acceso oDatos;

        public MPPPersona()
        {
            oDatos = new Acceso();
        }

        public Persona Login(string email, string password)
        {
            // Create a list of SqlParameter objects for the stored procedure
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Email", email));
            parameters.Add(new SqlParameter("@Password", Encriptacion.EncriptarPass(password)));

            DataTable personaData = oDatos.Leer("sp_Login", parameters);
            if (personaData.Rows.Count > 0)
            {
                DataRow personaRow = personaData.Rows[0];
                int id = Convert.ToInt32(personaRow["Id"]);
                string nombre = personaRow["Nombre"].ToString();
                string apellido = personaRow["Apellido"].ToString();
                string dni = personaRow["DNI"].ToString();
                string telefono = personaRow["Telefono"].ToString();
                DateTime fechaNacimiento = Convert.ToDateTime(personaRow["FechaNacimiento"]);
                string tipo = personaRow["Tipo"].ToString();

                return new Persona(id, nombre, apellido, dni, telefono, fechaNacimiento, email, password, tipo);
            }

            return null;
        }

        public bool GuardarUsuario(Persona item)
        {
            if (string.IsNullOrEmpty(item.Email) || string.IsNullOrEmpty(item.Password))
                throw new Exception("Los campos Email y Contraseña no pueden estar vacíos");
            string storedProcedure = "sp_GuardarPersona";
            bool resultado = false;
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", item.Id),
                new SqlParameter("@Email", item.Email),
                new SqlParameter("@Password", Encriptacion.EncriptarPass(item.Password))
            };
            try
            {
                resultado = oDatos.Escribir(storedProcedure, parametros);
            }
            catch (Exception ex)
            {
                resultado = false;
                throw ex;
            }
            return resultado;
        }

        public List<Persona> ListarTodo()
        {
            var personas = new List<Persona>();

            string storedProcedure = "ListarPersonas";
            DataTable tabla = oDatos.Leer(storedProcedure, null);

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    var persona = new Persona
                    (
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        fila["Apellido"].ToString(),
                        fila["DNI"].ToString(),
                        fila["Telefono"].ToString(),
                        Convert.ToDateTime(fila["FechaNacimiento"]),
                        fila["Email"].ToString(),
                        fila["Password"].ToString(),
                        fila["Tipo"].ToString()
                    );
                    personas.Add(persona);
                }
                return personas;
            }
            else
            {
                return null;
            }
        }
    }
}
