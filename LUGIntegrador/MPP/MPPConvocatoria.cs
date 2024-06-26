using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using UI_LUGIntegrador.Extensiones;


namespace MPP
{
    public class MPPConvocatoria : IGestor<Convocatoria>
    {
        private Acceso oDatos;
        private MPPJugador oMPPjugador;

        public MPPConvocatoria()
        {
            oDatos = new Acceso();
            oMPPjugador= new MPPJugador();
        }

        public List<Convocatoria> ListarTodo(bool include)
        {
            string storedProcedure = "sp_ListarConvocatorias";
            List<Convocatoria> listaConvocatorias = new List<Convocatoria>();
            DataTable tabla = oDatos.Leer(storedProcedure, null);

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    Convocatoria convocatoria = new Convocatoria(
                        Convert.ToInt64(fila["Id"]),
                        fila["Posicion"].ToString(),
                        Convert.ToBoolean(fila["Confirmacion"]),
                        Convert.ToDateTime(fila["Fecha"]),
                        TimeSpan.Parse(fila["Duracion"].ToString()),
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
            string storedProcedure = "sp_GuardarConvocatoria";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", SqlDbType.BigInt) { Value = convocatoria.Id, Direction = ParameterDirection.InputOutput },
                new SqlParameter("@Posicion", SqlDbType.NVarChar, 255) { Value = convocatoria.Posicion },
                new SqlParameter("@Confirmacion", SqlDbType.Bit) { Value = convocatoria.Confirmacion },
                new SqlParameter("@Fecha", SqlDbType.DateTime) { Value = convocatoria.Fecha },
                new SqlParameter("@Duracion", SqlDbType.Time) { Value = convocatoria.Duracion },
                new SqlParameter("@Ubicacion", SqlDbType.NVarChar, 255) { Value = convocatoria.Ubicacion },
                new SqlParameter("@JugadorId", SqlDbType.BigInt) { Value = convocatoria.Jugador.Id },
                new SqlParameter("@PartidoId", SqlDbType.BigInt) { Value = convocatoria.Partido.Id }
            };
            bool resultado = oDatos.Escribir(storedProcedure, parametros);
            if (convocatoria.Id == 0)
            {
                convocatoria.Id = Convert.ToInt64(parametros[0].Value);
            }
            return resultado;
        }

        public bool Baja(long Id)
        {
            string storedProcedure = "sp_EliminarConvocatoria";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", SqlDbType.BigInt) { Value = Id }
            };

            return oDatos.Escribir(storedProcedure, parametros);
        }

        public Convocatoria ListarObjeto(long Id)
        {
            string storedProcedure = "sp_ObtenerConvocatoriaPorId";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", SqlDbType.BigInt) { Value = Id }
            };
            DataTable tabla = oDatos.Leer(storedProcedure, parametros);
            if (tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                Jugador jugador = new MPPJugador().ListarObjeto(Convert.ToInt64(fila["JugadorId"]));
                Partido partido = new MPPPartido().ListarObjeto(Convert.ToInt64(fila["PartidoId"]));

                return new Convocatoria(
                    Convert.ToInt64(fila["Id"]),
                    fila["Posicion"].ToString(),
                    Convert.ToBoolean(fila["Confirmacion"]),
                    Convert.ToDateTime(fila["Fecha"]),
                    TimeSpan.Parse(fila["Duracion"].ToString()),
                    fila["Ubicacion"].ToString(),
                    jugador,
                    partido
                );
            }
            return null;
        }

        public bool CrearConvocatorias(Partido partido, Equipo equipo)
        {
            //Seria mejor mandar una lista a guardar no muchos ingresos a la db
            var jugadores = oMPPjugador.ListarJugadoresPorEquipo(equipo.Id);
            if (jugadores.IsNOTNullOrEmpty())
            {
                foreach (var item in jugadores)
                {
                    var convocatoria = new Convocatoria(0, item.Posicion, false, DateTime.Now, TimeSpan.Zero, partido.Ubicacion, item, partido);
                    Guardar(convocatoria);
                }
                return true;
            }
            else
                return false;
        }

        public List<Convocatoria> ListarConvocatoriasPorEquipoyPartido(Partido partido, Equipo equipo)
        {
            List<Convocatoria> listaConvocatorias = new List<Convocatoria>();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@PartidoId", partido.Id),
                new SqlParameter("@EquipoId", equipo.Id)
            };
            DataTable tabla = oDatos.Leer("sp_BuscarConvocatoriasPorEquipoyPartido", parametros);
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    Convocatoria convocatoria = new Convocatoria(
                        Convert.ToInt64(fila["Id"]),
                        fila["Posicion"].ToString(),
                        Convert.ToBoolean(fila["Confirmacion"]),
                        Convert.ToDateTime(fila["Fecha"]),
                        TimeSpan.Parse(fila["Duracion"].ToString()),
                        fila["Ubicacion"].ToString(),
                        null,
                        null
                    );
                    listaConvocatorias.Add(convocatoria);
                }
            }
            return listaConvocatorias;
        }

        public List<Convocatoria> ListarConFiltros(long? campeonatoId, long? equipoId, long? jugadorId, long? partidoId)
        {
            string storedProcedure = "sp_ListarConvocatoriasPorFiltros";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@CampeonatoId", SqlDbType.BigInt) { Value = (object)campeonatoId ?? DBNull.Value },
                new SqlParameter("@EquipoId", SqlDbType.BigInt) { Value = (object)equipoId ?? DBNull.Value },
                new SqlParameter("@JugadorId", SqlDbType.BigInt) { Value = (object)jugadorId ?? DBNull.Value },
                new SqlParameter("@PartidoId", SqlDbType.BigInt) { Value = (object)partidoId ?? DBNull.Value }
            };
            DataTable tabla = oDatos.Leer(storedProcedure, parametros);
            List<Convocatoria> listaConvocatorias = new List<Convocatoria>();

            foreach (DataRow fila in tabla.Rows)
            {
                Convocatoria convocatoria = new Convocatoria(
                    Convert.ToInt64(fila["Id"]),
                    fila["Posicion"].ToString(),
                    Convert.ToBoolean(fila["Confirmacion"]),
                    Convert.ToDateTime(fila["Fecha"]),
                    TimeSpan.Parse(fila["Duracion"].ToString()),
                    fila["Ubicacion"].ToString(),
                    new MPPJugador().ListarObjeto(Convert.ToInt64(fila["JugadorId"])), 
                    null  
                );

                listaConvocatorias.Add(convocatoria);
            }

            return listaConvocatorias;
        }
    }
}