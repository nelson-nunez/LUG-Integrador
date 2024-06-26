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
    public class MPPPartido : IGestor<Partido>
    {
        private Acceso oDatos;

        public MPPPartido()
        {
            oDatos = new Acceso();
        }

        public List<Partido> ListarTodo(bool include)
        {
            string storedProcedure = "sp_ListarPartidos";
            List<Partido> listaPartidos = new List<Partido>();
            DataTable tabla = oDatos.Leer(storedProcedure, null);
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    Partido partido = new Partido(
                        Convert.ToInt64(fila["Id"]),
                        Convert.ToDateTime(fila["Fecha"]),
                        Convert.ToInt32(fila["Duracion"]),
                        Convert.ToInt32(fila["NumeroCancha"]),
                        fila["Ubicacion"].ToString(),
                        fila["Categoria"].ToString(),
                        null,
                        null,
                        null
                    );

                    listaPartidos.Add(partido);
                }
            }
            return listaPartidos;
        }

        public bool Guardar(Partido partido)
        {
            string storedProcedure = "sp_GuardarPartido";
            bool resultado = false;
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", partido.Id),
                new SqlParameter("@Fecha", partido.Fecha),
                new SqlParameter("@Duracion", partido.Duracion),
                new SqlParameter("@NumeroCancha", partido.NumeroCancha),
                new SqlParameter("@Ubicacion", partido.Ubicacion),
                new SqlParameter("@Categoria", partido.Categoria)
            };
            try
            {
                resultado = oDatos.Escribir(storedProcedure, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public bool Baja(long Id)
        {
            string storedProcedure = "sp_BajaPartido";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", Id)
            };
            try
            {
                return oDatos.Escribir(storedProcedure, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Partido ListarObjeto(long Id)
        {
            string storedProcedure = "sp_ListarPartidoPorId";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", Id)
            };
            try
            {
                DataTable tabla = oDatos.Leer(storedProcedure, parametros);

                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    return new Partido(
                        Convert.ToInt64(fila["Id"]),
                        Convert.ToDateTime(fila["Fecha"]),
                        Convert.ToInt32(fila["Duracion"]),
                        Convert.ToInt32(fila["NumeroCancha"]),
                        fila["Ubicacion"].ToString(),
                        fila["Categoria"].ToString(),
                        null,
                        null,
                        null
                    );
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Partido> ListarPartidosPorJugador(long jugadorId)
        {
            string storedProcedure = "sp_ListarPartidosPorJugador";
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@JugadorId", jugadorId)
            };

            DataTable tabla = oDatos.Leer(storedProcedure, parametros);
            List<Partido> listaPartidos = new List<Partido>();

            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    Partido partido = new Partido(
                        Convert.ToInt64(fila["Id"]),
                        Convert.ToDateTime(fila["Fecha"]),
                        Convert.ToInt32(fila["Duracion"]),
                        Convert.ToInt32(fila["NumeroCancha"]),
                        fila["Ubicacion"].ToString(),
                        fila["Categoria"].ToString(),
                        null,
                        null,
                        null
                    );
                    listaPartidos.Add(partido);
                }
            }
            return listaPartidos;
        }

    }
}
