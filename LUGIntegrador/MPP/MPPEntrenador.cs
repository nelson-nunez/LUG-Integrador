using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace MPP
{
    public class MPPEntrenador : IGestor<Entrenador>
    {
        private Acceso oDatos;

        public MPPEntrenador()
        {
            oDatos = new Acceso();
        }

        public List<Entrenador> ListarTodo()
        {
            string consulta = "SELECT Id, Nombre, Apellido, DNI, Telefono, FechaNacimiento, NumeroLicencia, EquipoId, Titulo FROM Entrenador";
            DataSet ds = oDatos.Leer2(consulta);
            List<Entrenador> listaEntrenadores = new List<Entrenador>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    Equipo equipo = new MPPEquipo().ListarObjeto(Convert.ToInt64(fila["EquipoId"]));

                    Entrenador entrenador = new Entrenador(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        fila["Apellido"].ToString(),
                        fila["DNI"].ToString(),
                        fila["Telefono"].ToString(),
                        Convert.ToDateTime(fila["FechaNacimiento"]),
                        fila["NumeroLicencia"].ToString(),
                        fila["Titulo"].ToString(),
                        equipo
                    );

                    listaEntrenadores.Add(entrenador);
                }
            }
            return listaEntrenadores;
        }

        public bool Guardar(Entrenador entrenador)
        {
            string consultaSQL;
            if (entrenador.Id != 0)
            {
                consultaSQL = $"UPDATE Entrenador SET Nombre = '{entrenador.Nombre}', Apellido = '{entrenador.Apellido}', DNI = '{entrenador.DNI}', Telefono = '{entrenador.Telefono}', FechaNacimiento = '{entrenador.FechaNacimiento:yyyy-MM-dd}', NumeroLicencia = '{entrenador.NumeroLicencia}', Titulo = '{entrenador.Titulo}' WHERE Id = {entrenador.Id}";
            }
            else
            {
                consultaSQL = $"INSERT INTO Entrenador (Nombre, Apellido, DNI, Telefono, FechaNacimiento, NumeroLicencia, Titulo) VALUES ('{entrenador.Nombre}', '{entrenador.Apellido}', '{entrenador.DNI}', '{entrenador.Telefono}', '{entrenador.FechaNacimiento:yyyy-MM-dd}', '{entrenador.NumeroLicencia}', '{entrenador.Titulo}')";
            }
            return oDatos.Escribir(consultaSQL);
        }

        public bool Baja(long Id)
        {
            string consultaSQL = $"DELETE FROM Entrenador WHERE Id = {Id}";
            return oDatos.Escribir(consultaSQL);
        }

        public Entrenador ListarObjeto(long Id)
        {
            string consulta = $"SELECT Id, Nombre, Apellido, DNI, Telefono, FechaNacimiento, NumeroLicencia, Titulo FROM Entrenador WHERE Id = {Id}";
            DataSet ds = oDatos.Leer2(consulta);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                return new Entrenador(
                    Convert.ToInt64(fila["Id"]),
                    fila["Nombre"].ToString(),
                    fila["Apellido"].ToString(),
                    fila["DNI"].ToString(),
                    fila["Telefono"].ToString(),
                    Convert.ToDateTime(fila["FechaNacimiento"]),
                    fila["NumeroLicencia"].ToString(),
                    fila["Titulo"].ToString(),
                    null // Equipo se asignará después
                );
            }
            return null;
        }
    }
}
