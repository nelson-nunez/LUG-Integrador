using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPEquipo : IGestor<Equipo>
    {
        private Acceso oDatos;

        public MPPEquipo()
        {
            oDatos = new Acceso();
        }

        public List<Equipo> ListarTodo()
        {
            string consulta = "SELECT Id, Nombre, Descripcion, EntrenadorId FROM Equipo";
            DataSet ds = oDatos.Leer2(consulta);
            List<Equipo> listaEquipos = new List<Equipo>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    Entrenador entrenador = new MPPEntrenador().ListarObjeto(Convert.ToInt64(fila["EntrenadorId"]));
                    List<Jugador> jugadores = new MPPJugador().ListarJugadoresPorEquipo(Convert.ToInt64(fila["Id"]));
                    Equipo equipo = new Equipo(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        fila["Descripcion"].ToString(),
                        entrenador,
                        jugadores
                    );

                    listaEquipos.Add(equipo);
                }
            }
            return listaEquipos;
        }

        public bool Guardar(Equipo equipo)
        {
            long entrenadorId = equipo.Entrenador != null ? equipo.Entrenador.Id : 0;
            string consultaSQL;
            if (equipo.Id != 0)
            {
                consultaSQL = $"UPDATE Equipo SET Nombre = '{equipo.Nombre}', Descripcion = '{equipo.Descripcion}', EntrenadorId = {entrenadorId} WHERE Id = {equipo.Id}";
            }
            else
            {
                consultaSQL = $"INSERT INTO Equipo (Nombre, Descripcion, EntrenadorId) VALUES ('{equipo.Nombre}', '{equipo.Descripcion}', {entrenadorId})";
            }
            return oDatos.Escribir(consultaSQL);
        }

        public bool Baja(long Id)
        {
            string consultaSQL = $"DELETE FROM Equipo WHERE Id = {Id}";
            return oDatos.Escribir(consultaSQL);
        }

        public Equipo ListarObjeto(long Id)
        {
            string consulta = $"SELECT Id, Nombre, Descripcion, EntrenadorId FROM Equipo WHERE Id = {Id}";
            DataSet ds = oDatos.Leer2(consulta);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                long entrenadorId = Convert.ToInt64(fila["EntrenadorId"]);
                Entrenador entrenador = new MPPEntrenador().ListarObjeto(entrenadorId);

                return new Equipo(
                    Convert.ToInt64(fila["Id"]),
                    fila["Nombre"].ToString(),
                    fila["Descripcion"].ToString(),
                    entrenador,
                    null // Jugadores se asignarán después
                );
            }
            return null;
        }
    }
}
