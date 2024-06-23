using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPPersona
    {
        private Acceso oDatos;

        public MPPPersona()
        {
            oDatos = new Acceso();
        }

        public PersonaView Login(string email, string password)
        {
            string consulta =
                $"SELECT p.Id, p.Nombre, p.Apellido, p.DNI, p.Telefono, " +
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
                return new PersonaView(
                    Convert.ToInt64(fila["Id"]),
                    fila["Nombre"].ToString(),
                    fila["Apellido"].ToString(),
                    fila["DNI"].ToString(),
                    fila["Telefono"].ToString(),
                    fila["Tipo"].ToString()
                );
            }

            return null;
        }

        public bool GuardarUsuario(long Id, string email, string password)
        {
            string selectQuery = $"SELECT Id FROM Persona WHERE Id = {Id}";
            DataSet ds = oDatos.Leer2(selectQuery);
            if (ds.Tables[0].Rows.Count > 0)
            {
                string updateQuery = $"UPDATE Persona SET Email = '{email}', Password = '{password}' WHERE Id = {Id}";
                return oDatos.Escribir(updateQuery);
            }
            else
            {
                throw new Exception("No existe la persona con el Id especificado.");
            }
        }

        public List<PersonaView> ListarTodo()
        {
            var personas = new List<PersonaView>();

            string storedProcedure = "ListarPersonas";
            DataTable tabla = oDatos.Leer(storedProcedure, null);

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow row in tabla.Rows)
                {
                    var persona = new PersonaView
                    (
                        Convert.ToInt64(row["Id"]),
                        row["Nombre"].ToString(),
                        row["Apellido"].ToString(),
                        row["DNI"].ToString(),
                        row["Telefono"].ToString(),
                        row["Tipo"].ToString()
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
