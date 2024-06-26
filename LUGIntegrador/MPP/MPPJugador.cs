using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPP
{
    public class MPPJugador : IGestor<Jugador>
    {
        private Acceso oDatos;

        public MPPJugador()
        {
            oDatos = new Acceso();
        }

        public List<Jugador> ListarTodo(bool include)
        {
            string storedProcedure = "sp_ListarJugadores";
            List<Jugador> listaJugadores = new List<Jugador>();
            DataTable tabla = oDatos.Leer(storedProcedure, null);
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    Jugador jugador = new Jugador(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        fila["Apellido"].ToString(),
                        fila["DNI"].ToString(),
                        fila["Telefono"].ToString(),
                        Convert.ToDateTime(fila["FechaNacimiento"]),
                        fila["Email"].ToString(),
                        null,
                        fila["Posicion"].ToString(),
                        Convert.ToInt32(fila["Edad"]),
                        Convert.ToInt32(fila["Altura"]),
                        Convert.ToInt32(fila["Peso"]),
                        include ? new MPPEquipo().ListarObjeto(Convert.ToInt64(fila["EquipoId"])) : null,
                        include ? new MPPPartido().ListarPartidosPorJugador(Convert.ToInt64(fila["Id"])) : null,
                        include ? new MPPConvocatoria().ListarConFiltros(0,0,Convert.ToInt64(fila["Id"]), 0) : null
                    );

                    listaJugadores.Add(jugador);
                }
            }
            return listaJugadores;
        }

        public bool Guardar(Jugador jugador)
        {
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", SqlDbType.BigInt) { Direction = ParameterDirection.Output },
                new SqlParameter("@Nombre", jugador.Nombre),
                new SqlParameter("@Apellido", jugador.Apellido),
                new SqlParameter("@DNI", jugador.DNI),
                new SqlParameter("@Telefono", jugador.Telefono),
                new SqlParameter("@FechaNacimiento", jugador.FechaNacimiento),
                new SqlParameter("@Email", jugador.Email),
                new SqlParameter("@Password", jugador.Password),
                new SqlParameter("@Posicion", jugador.Posicion),
                new SqlParameter("@Edad", jugador.Edad),
                new SqlParameter("@Altura", jugador.Altura),
                new SqlParameter("@Peso", jugador.Peso),
                new SqlParameter("@EquipoId", jugador.Equipo?.Id)
            };

            oDatos.Escribir("sp_InsertarJugador", parametros);
            return true;
        }

        public bool Baja(long Id)
        {
            string storedProcedure = "sp_BorrarJugador";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", Id)
            };
            return oDatos.Escribir(storedProcedure, parametros);
        }

        public Jugador ListarObjeto(long Id)
        {
            string storedProcedure = "sp_ListarJugadorPorId";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", Id)
            };
            DataTable tabla = oDatos.Leer(storedProcedure, parametros);

            if (tabla.Rows.Count > 0)
            {
                DataRow fila = tabla.Rows[0];
                return new Jugador(
                    Convert.ToInt64(fila["Id"]),
                    fila["Nombre"].ToString(),
                    fila["Apellido"].ToString(),
                    fila["DNI"].ToString(),
                    fila["Telefono"].ToString(),
                    Convert.ToDateTime(fila["FechaNacimiento"]),
                    fila["Email"].ToString(),
                    null,
                    fila["Posicion"].ToString(),
                    Convert.ToInt32(fila["Edad"]),
                    Convert.ToInt32(fila["Altura"]),
                    Convert.ToInt32(fila["Peso"]),
                    null,
                    null,
                    null
                );
            }
            return null;
        }

        public List<Jugador> ListarJugadoresPorEquipo(long equipoId)
        {
            string storedProcedure = "sp_ListarJugadoresPorEquipo";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@EquipoId", equipoId)
            };

            DataTable tabla = oDatos.Leer(storedProcedure, parametros);
            List<Jugador> listaJugadores = new List<Jugador>();

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    Jugador jugador = new Jugador(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        fila["Apellido"].ToString(),
                        fila["DNI"].ToString(),
                        fila["Telefono"].ToString(),
                        Convert.ToDateTime(fila["FechaNacimiento"]),
                        fila["Email"].ToString(),
                        null,
                        fila["Posicion"].ToString(),
                        Convert.ToInt32(fila["Edad"]),
                        Convert.ToInt32(fila["Altura"]),
                        Convert.ToInt32(fila["Peso"]),
                        null,
                        null,
                        null
                    );
                    listaJugadores.Add(jugador);
                }
            }
            return listaJugadores;
        }

    }
}
