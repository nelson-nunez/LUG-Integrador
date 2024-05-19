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
    public class MPPCampeonato : IGestor<Campeonato>
    {
        private Acceso oDatos;

        public MPPCampeonato()
        {
            oDatos = new Acceso();
        }

        public List<Campeonato> ListarTodo()
        {
            string consulta = "SELECT Id, Nombre, FechaInicio, FechaFin, CantidadPartidos, CantidadJugadores FROM Campeonato";
            DataSet ds = oDatos.Leer2(consulta);
            List<Campeonato> listaCampeonatos = new List<Campeonato>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    Campeonato campeonato = new Campeonato(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        Convert.ToDateTime(fila["FechaInicio"]),
                        Convert.ToDateTime(fila["FechaFin"]),
                        Convert.ToInt32(fila["CantidadPartidos"]),
                        Convert.ToInt32(fila["CantidadJugadores"])
                    );

                    listaCampeonatos.Add(campeonato);
                }
            }
            return listaCampeonatos;
        }

        public bool Guardar(Campeonato campeonato)
        {
            string consultaSQL;
            if (campeonato.Id != 0)
            {
                consultaSQL = $"UPDATE Campeonato SET Nombre = '{campeonato.Nombre}', FechaInicio = '{campeonato.FechaInicio:yyyy-MM-dd}', FechaFin = '{campeonato.FechaFin:yyyy-MM-dd}', CantidadPartidos = {campeonato.CantidadPartidos}, CantidadJugadores = {campeonato.CantidadJugadores} WHERE Id = {campeonato.Id}";
            }
            else
            {
                consultaSQL = $"INSERT INTO Campeonato (Nombre, FechaInicio, FechaFin, CantidadPartidos, CantidadJugadores) VALUES ('{campeonato.Nombre}', '{campeonato.FechaInicio:yyyy-MM-dd}', '{campeonato.FechaFin:yyyy-MM-dd}', {campeonato.CantidadPartidos}, {campeonato.CantidadJugadores})";
            }
            return oDatos.Escribir(consultaSQL);
        }

        public bool AgregarPartido(Campeonato campeonato, Partido partido)
        {
            string consulta = $"INSERT INTO Partido (CampeonatoId, EquipoLocal, EquipoVisitante, Fecha) VALUES ({campeonato.Id}, '{partido.EquipoLocal}', '{partido.EquipoVisitante}', '{partido.Fecha:yyyy-MM-dd HH:mm:ss}')";
            return oDatos.Escribir(consulta);
        }

        public bool QuitarPartido(Campeonato campeonato, Partido partido)
        {
            string consulta = $"DELETE FROM Partido WHERE CampeonatoId = {campeonato.Id} AND Id = {partido.Id}";
            return oDatos.Escribir(consulta);
        }

        public bool Baja(Campeonato campeonato)
        {
            string consultaSQL = $"DELETE FROM Campeonato WHERE Id = {campeonato.Id}";
            return oDatos.Escribir(consultaSQL);
        }

        public Campeonato ListarObjeto(Campeonato campeonato)
        {
            string consulta = $"SELECT Id, Nombre, FechaInicio, FechaFin, CantidadPartidos, CantidadJugadores FROM Campeonato WHERE Id = {campeonato.Id}";
            DataSet ds = oDatos.Leer2(consulta);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                return new Campeonato(
                    Convert.ToInt64(fila["Id"]),
                    fila["Nombre"].ToString(),
                    Convert.ToDateTime(fila["FechaInicio"]),
                    Convert.ToDateTime(fila["FechaFin"]),
                    Convert.ToInt32(fila["CantidadPartidos"]),
                    Convert.ToInt32(fila["CantidadJugadores"])
                );
            }
            return null;
        }
    }
}
