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

        public List<Equipo> ListarTodo(bool include= false)
        {
            string consulta = "SELECT Id, Nombre, Descripcion, EntrenadorId FROM Equipo";
            DataSet ds = oDatos.Leer2(consulta);
            List<Equipo> listaEquipos = new List<Equipo>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    Equipo equipo = new Equipo(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        fila["Descripcion"].ToString(),
                        include ? new MPPJugador().ListarJugadoresPorEquipo(Convert.ToInt64(fila["Id"])) : null
                    );
                    listaEquipos.Add(equipo);
                }
            }
            return listaEquipos;
        }

        public bool Guardar(Equipo equipo)
        {
            string consultaSQL;
            if (equipo.Id != 0)
            {
                consultaSQL = $"UPDATE Equipo SET Nombre = '{equipo.Nombre}', Descripcion = '{equipo.Descripcion}', WHERE Id = {equipo.Id}";
            }
            else
            {
                consultaSQL = $"INSERT INTO Equipo (Nombre, Descripcion, EntrenadorId) VALUES ('{equipo.Nombre}', '{equipo.Descripcion}')";
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
                return new Equipo(
                    Convert.ToInt64(fila["Id"]),
                    fila["Nombre"].ToString(),
                    fila["Descripcion"].ToString(),
                    null // Jugadores se asignarán después
                );
            }
            return null;
        }

        public bool EliminarJugadordeEquipo(long equipoId, long jugadorId)
        {
            string consultaSQL = $"UPDATE Jugador SET EquipoId = NULL WHERE Id = {jugadorId} AND EquipoId = {equipoId}";
            return oDatos.Escribir(consultaSQL);
        }
        public bool AñadirJugadorAEquipo(long equipoId, long jugadorId)
        {
            string consultaSQL = $"UPDATE Jugador SET EquipoId = {equipoId} WHERE Id = {jugadorId}";
            return oDatos.Escribir(consultaSQL);
        }

    }
}
