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
    public class MPPConvocatoria : IGestor<Convocatoria>
    {
        private Acceso oDatos;

        public MPPConvocatoria()
        {
            oDatos = new Acceso();
        }

        public List<Convocatoria> ListarTodo(bool include)
        {
            string consulta = "SELECT Id, Posicion, Confirmacion, Fecha, Duracion, Ubicacion, JugadorId, PartidoId FROM Convocatoria";
            DataSet ds = oDatos.Leer2(consulta);
            List<Convocatoria> listaConvocatorias = new List<Convocatoria>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    Convocatoria convocatoria = new Convocatoria(
                        Convert.ToInt64(fila["Id"]),
                        fila["Posicion"].ToString(),
                        Convert.ToBoolean(fila["Confirmacion"]),
                        Convert.ToDateTime(fila["Fecha"]),
                        TimeSpan.FromHours(Convert.ToDouble(fila["Duracion"])),
                        fila["Ubicacion"].ToString(),
                        include ? new MPPJugador().ListarObjeto(Convert.ToInt64(fila["JugadorId"])) : null,
                        include ? new MPPPartido().ListarObjeto(Convert.ToInt64(fila["PartidoId"])) : null
                        );

                    listaConvocatorias.Add(convocatoria);
                }
            }
            return listaConvocatorias;
        }

        public bool Guardar(Convocatoria convocatoria)
        {
            bool resultadoJugador = new MPPJugador().Guardar(convocatoria.Jugador);
            bool resultadoPartido = new MPPPartido().Guardar(convocatoria.Partido);

            if (!resultadoJugador || !resultadoPartido)
            {
                return false;
            }

            string consultaSQL;
            if (convocatoria.Id != 0)
            {
                consultaSQL = $"UPDATE Convocatoria SET Posicion = '{convocatoria.Posicion}', Confirmacion = {Convert.ToInt32(convocatoria.Confirmacion)}, Fecha = '{convocatoria.Fecha:yyyy-MM-dd HH:mm:ss}', Duracion = {convocatoria.Duracion.TotalHours}, Ubicacion = '{convocatoria.Ubicacion}', JugadorId = {convocatoria.Jugador.Id}, PartidoId = {convocatoria.Partido.Id} WHERE Id = {convocatoria.Id}";
            }
            else
            {
                consultaSQL = $"INSERT INTO Convocatoria (Posicion, Confirmacion, Fecha, Duracion, Ubicacion, JugadorId, PartidoId) VALUES ('{convocatoria.Posicion}', {Convert.ToInt32(convocatoria.Confirmacion)}, '{convocatoria.Fecha:yyyy-MM-dd HH:mm:ss}', '{convocatoria.Duracion:hh\\:mm\\:ss}', '{convocatoria.Ubicacion}', {convocatoria.Jugador.Id}, {convocatoria.Partido.Id})";
            }
            return oDatos.Escribir(consultaSQL);
        }

        public bool Baja(long Id)
        {
            string consultaSQL = $"DELETE FROM Convocatoria WHERE Id = {Id}";
            return oDatos.Escribir(consultaSQL);
        }

        public Convocatoria ListarObjeto(long Id)
        {
            string consulta = $"SELECT Id, Posicion, Confirmacion, Fecha, Duracion, Ubicacion, JugadorId, PartidoId FROM Convocatoria WHERE Id = {Id}";
            DataSet ds = oDatos.Leer2(consulta);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                Jugador jugador = new MPPJugador().ListarObjeto(Convert.ToInt64(fila["JugadorId"]));
                Partido partido = new MPPPartido().ListarObjeto(Convert.ToInt64(fila["PartidoId"]));

                return new Convocatoria(
                    Convert.ToInt64(fila["Id"]),
                    fila["Posicion"].ToString(),
                    Convert.ToBoolean(fila["Confirmacion"]),
                    Convert.ToDateTime(fila["Fecha"]),
                    TimeSpan.FromHours(Convert.ToDouble(fila["Duracion"])),
                    fila["Ubicacion"].ToString(),
                    jugador,
                    partido
                );
            }
            return null;
        }

        public List<Convocatoria> ListarConvocatoriasPorJugador(long jugadorId)
        {
            string consulta = $"SELECT Id, Posicion, Confirmacion, Fecha, Duracion, Ubicacion, JugadorId, PartidoId FROM Convocatoria WHERE JugadorId = {jugadorId}";
            DataSet ds = oDatos.Leer2(consulta);
            List<Convocatoria> listaConvocatorias = new List<Convocatoria>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    Convocatoria convocatoria = new Convocatoria(
                        Convert.ToInt64(fila["Id"]),
                        fila["Posicion"].ToString(),
                        Convert.ToBoolean(fila["Confirmacion"]),
                        Convert.ToDateTime(fila["Fecha"]),
                        (TimeSpan)fila["Duracion"],
                        fila["Ubicacion"].ToString(),
                        null,
                        null
                    );

                    listaConvocatorias.Add(convocatoria);
                }
            }
            return listaConvocatorias;
        }

    }
}