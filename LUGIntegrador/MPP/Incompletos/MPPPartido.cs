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
    public class MPPPartido : IGestor<Partido>
    {
        private Acceso oDatos;

        public MPPPartido()
        {
            oDatos = new Acceso();
        }

        public List<Partido> ListarTodo(bool include)
        {
            string consulta = "SELECT Id, Fecha, Duracion, NumeroCancha, Ubicacion, Categoria FROM Partido";
            DataSet ds = oDatos.Leer2(consulta);
            List<Partido> listaPartidos = new List<Partido>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
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
            string consultaSQL;
            if (partido.Id != 0)
            {
                consultaSQL = $"UPDATE Partido SET Fecha = '{partido.Fecha:yyyy-MM-dd}', Duracion = {partido.Duracion}, NumeroCancha = {partido.NumeroCancha}, Ubicacion = '{partido.Ubicacion}', Categoria = '{partido.Categoria}' WHERE Id = {partido.Id}";
            }
            else
            {
                consultaSQL = $"INSERT INTO Partido (Fecha, Duracion, NumeroCancha, Ubicacion, Categoria) VALUES ('{partido.Fecha:yyyy-MM-dd}', {partido.Duracion}, {partido.NumeroCancha}, '{partido.Ubicacion}', '{partido.Categoria}')";
            }
            return oDatos.Escribir(consultaSQL);
        }

        public bool Baja(long Id)
        {
            string consultaSQL = $"DELETE FROM Partido WHERE Id = {Id}";
            return oDatos.Escribir(consultaSQL);
        }

        public Partido ListarObjeto(long Id)
        {
            string consulta = $"SELECT Id, Fecha, Duracion, NumeroCancha, Ubicacion, Categoria FROM Partido WHERE Id = {Id}";
            DataSet ds = oDatos.Leer2(consulta);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                return new Partido(
                    Convert.ToInt64(fila["Id"]),
                    Convert.ToDateTime(fila["Fecha"]),
                    Convert.ToInt32(fila["Duracion"]),
                    Convert.ToInt32(fila["NumeroCancha"]),
                    fila["Ubicacion"].ToString(),
                    fila["Categoria"].ToString(),null,null,null
                );
            }
            return null;
        }

        public List<Partido> ListarPartidosPorJugador(long jugadorId)
        {
            string consulta = $"SELECT p.Id, p.Fecha, p.Duracion, p.NumeroCancha, p.Ubicacion, p.Categoria " +
                              $"FROM Partido p " +
                              $"JOIN Convocatoria c ON p.Id = c.PartidoId " +
                              $"WHERE c.JugadorId = {jugadorId}";
            DataSet ds = oDatos.Leer2(consulta);
            List<Partido> listaPartidos = new List<Partido>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
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
