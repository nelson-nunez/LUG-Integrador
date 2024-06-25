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
    public class MPPEquipo : IGestor<Equipo>
    {
        private Acceso oDatos;

        public MPPEquipo()
        {
            oDatos = new Acceso();
        }

        public List<Equipo> ListarTodo(bool include)
        {
            string storedProcedure = "sp_ListarEquipos";
            List<Equipo> listaEquipos = new List<Equipo>();
            try
            {
                DataTable tabla = oDatos.Leer(storedProcedure, null);
                if (tabla.Rows.Count > 0)
                {
                    foreach (DataRow fila in tabla.Rows)
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
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return listaEquipos;
        }

        public bool Guardar(Equipo equipo)
        {
            string storedProcedure = "sp_GuardarEquipo";
            bool resultado = false;
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@Id", equipo.Id),
                    new SqlParameter("@Nombre", equipo.Nombre),
                    new SqlParameter("@Descripcion", equipo.Descripcion),
                };

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
            string storedProcedure = "sp_BajaEquipo";
            bool resultado = false;
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@Id", Id)
                };
                resultado = oDatos.Escribir(storedProcedure, parametros);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return resultado;
        }

        public Equipo ListarObjeto(long Id)
        {
            string storedProcedure = "sp_ListarEquipoPorId";
            Equipo equipo = null;
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>
                {
                    new SqlParameter("@Id", Id)
                };
                DataTable tabla = oDatos.Leer(storedProcedure, parametros);
                if (tabla.Rows.Count > 0)
                {
                    DataRow fila = tabla.Rows[0];
                    equipo = new Equipo(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        fila["Descripcion"].ToString(),
                        null // La lista de jugadores se asignará después si es necesario
                    );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return equipo;
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
