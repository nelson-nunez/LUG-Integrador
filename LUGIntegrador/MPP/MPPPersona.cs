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
            string consulta =
                "SELECT p.Id, p.Nombre, p.Apellido, p.DNI, p.Telefono, p.FechaNacimiento, " +
                $"CASE " +
                $"    WHEN j.Id IS NOT NULL THEN 'Jugador' " +
                $"    WHEN t.Id IS NOT NULL THEN 'Tecnico' " +
                $"END AS Tipo " +
                $"FROM Persona p " +
                $"LEFT JOIN Jugador j ON p.Id = j.Id " +
                $"LEFT JOIN Tecnico t ON p.Id = t.Id " +
                $"WHERE p.Email = '{email}' AND p.Password = '{password}'";

            DataSet ds = oDatos.Leer2(consulta);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                return new Persona(
                    Convert.ToInt64(fila["Id"]),
                    fila["Nombre"].ToString(),
                    fila["Apellido"].ToString(),
                    fila["DNI"].ToString(),
                    fila["Telefono"].ToString(),
                    Convert.ToDateTime(fila["FechaNacimiento"]),
                    email,
                    password,
                    fila["Tipo"].ToString()
                );
            }

            return null;
        }

        public bool GuardarUsuario(Persona item)
        {
            if (string.IsNullOrEmpty(item.Email) || string.IsNullOrEmpty(item.Password))
                throw new Exception("Los campos Email y Contraseña no pueden estar vacíos");

            string selectQuery = $"SELECT Id FROM Persona WHERE Id = {item.Id}";
            DataSet ds = oDatos.Leer2(selectQuery);
            if (ds.Tables[0].Rows.Count > 0)
            {
                //La encripto para gardarla
                var encpass= Encriptacion.EncriptarPass(item.Password);
                string updateQuery = $"UPDATE Persona SET Email = '{item.Email}', Password = '{encpass}' WHERE Id = {item.Id}";
                return oDatos.Escribir(updateQuery);
            }
            else
                throw new Exception("No existe la persona con el Id especificado.");
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
