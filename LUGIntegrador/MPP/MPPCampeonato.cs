using Abstraccion;
using BE;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.IO;
using System.Xml.Linq;

namespace MPP
{

    public class MPPCampeonato : IGestor<Campeonato>
    {
        private Acceso oDatos;

        public MPPCampeonato()
        {
            oDatos = new Acceso();
        }

        public List<Campeonato> ListarTodo(bool include)
        {
            string storedProcedure = "sp_ListarCampeonatos";
            List<Campeonato> listaCampeonatos = new List<Campeonato>();
            DataTable tabla = oDatos.Leer(storedProcedure, null);
            if (tabla.Rows.Count > 0)
            {
                foreach (DataRow fila in tabla.Rows)
                {
                    Campeonato campeonato = new Campeonato(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        Convert.ToDateTime(fila["FechaInicio"]),
                        Convert.ToDateTime(fila["FechaFin"]),
                        Convert.ToInt32(fila["CantidadPartidos"]),
                        Convert.ToInt32(fila["CantidadJugadores"]),
                        include ? ListarPartidosPorCampeonato(Convert.ToInt64(fila["Id"])) : null
                    );

                    listaCampeonatos.Add(campeonato);
                }
            }
            return listaCampeonatos;
        }

        private List<Partido> ListarPartidosPorCampeonato(long campeonatoId)
        {
            string storedProcedure = "sp_ListarPartidosPorCampeonato";
            List<Partido> listaPartidos = new List<Partido>();
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@CampeonatoId", campeonatoId)
            };
            DataTable tabla = oDatos.Leer(storedProcedure, parametros);
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

        public bool Guardar(Campeonato campeonato)
        {
            string storedProcedure = "sp_GuardarCampeonato";
            bool resultado = false;
            List<SqlParameter> parametros = new List<SqlParameter>
            {
                new SqlParameter("@Id", campeonato.Id),
                new SqlParameter("@Nombre", campeonato.Nombre),
                new SqlParameter("@FechaInicio", campeonato.FechaInicio),
                new SqlParameter("@FechaFin", campeonato.FechaFin),
                new SqlParameter("@CantidadPartidos", campeonato.CantidadPartidos),
                new SqlParameter("@CantidadJugadores", campeonato.CantidadJugadores),
            };
            try
            {
                resultado = oDatos.Escribir(storedProcedure, parametros);
                if (resultado && campeonato.Partidos != null && campeonato.Partidos.Count > 0)
                {
                    XElement xmlPartidos = new XElement("Partidos",
                        from partido in campeonato.Partidos
                        select new XElement("Partido",
                            new XElement("Fecha", partido.Fecha),
                            new XElement("Duracion", partido.Duracion),
                            new XElement("NumeroCancha", partido.NumeroCancha),
                            new XElement("Ubicacion", partido.Ubicacion),
                            new XElement("Categoria", partido.Categoria),
                            new XElement("CampeonatoId", partido.Campeonato.Id)
                        )
                    );
                    string xmlString = xmlPartidos.ToString();
                    SqlParameter paramXmlPartidos = new SqlParameter("@XmlPartidos", SqlDbType.Xml);
                    paramXmlPartidos.Value = new SqlXml(new XmlTextReader(new StringReader(xmlString)));
                    resultado = oDatos.Escribir("sp_InsertarListaPartidos", new List<SqlParameter> { paramXmlPartidos });
                }
            }
            catch (Exception ex)
            {
                resultado = false;
                throw ex;
            }

            return resultado;
        }

        public bool Baja(long Id)
        {
            string storedProcedure = "sp_BajaCampeonato";
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
                Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                return false;
            }
        }

        public Campeonato ListarObjeto(long Id)
        {
            string storedProcedure = "sp_ListarCampeonatoPorId";
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
                    return new Campeonato(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        Convert.ToDateTime(fila["FechaInicio"]),
                        Convert.ToDateTime(fila["FechaFin"]),
                        Convert.ToInt32(fila["CantidadPartidos"]),
                        Convert.ToInt32(fila["CantidadJugadores"]),
                        ListarPartidosPorCampeonato(Convert.ToInt64(fila["Id"]))
                    );
                }
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar el procedimiento almacenado: " + ex.Message);
                return null;
            }
        }

    }
}
