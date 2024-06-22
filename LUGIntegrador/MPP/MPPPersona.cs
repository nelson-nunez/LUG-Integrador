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

        public Persona Login(string email, string password)
        {
            string consulta =
                $"SELECT Id, Nombre, Apellido, DNI, Telefono, FechaNacimiento, Email, Password, 'Jugador' AS Tipo " +
                $"FROM Jugador WHERE Email ='{email}' AND Password ='{password}' " +
                $"UNION " +
                $"SELECT Id, Nombre, Apellido, DNI, Telefono, FechaNacimiento, Email, Password, 'Tecnico' AS Tipo " +
                $"FROM Tecnico WHERE Email ='{email}' AND Password ='{password}'";

            DataSet ds = oDatos.Leer2(consulta);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                string tipo = fila["Tipo"].ToString();
                if (tipo == "Jugador")
                {
                    return new Jugador(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        fila["Apellido"].ToString(),
                        fila["DNI"].ToString(),
                        fila["Telefono"].ToString(),
                        Convert.ToDateTime(fila["FechaNacimiento"]),
                        fila["Email"].ToString(),
                        fila["Password"].ToString(),
                        null, 
                        0, 
                        0, 
                        0, 
                        null, 
                        null, 
                        null  
                    );
                }
                else if (tipo == "Tecnico")
                {
                    return new Tecnico(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        fila["Apellido"].ToString(),
                        fila["DNI"].ToString(),
                        fila["Telefono"].ToString(),
                        Convert.ToDateTime(fila["FechaNacimiento"]),
                        fila["Email"].ToString(),
                        fila["Password"].ToString(),
                        null,
                        0, 
                        null  
                    );
                }
            }

            return null;
        }
    }

}
