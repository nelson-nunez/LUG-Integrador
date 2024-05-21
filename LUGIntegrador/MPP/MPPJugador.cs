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
    public class MPPJugador : IGestor<Jugador>
    {
        private Acceso oDatos;

        public MPPJugador()
        {
            oDatos = new Acceso();
        }

        public List<Jugador> ListarTodo()
        {
            string consulta = "SELECT Id, Nombre, Apellido, DNI, Telefono, FechaNacimiento, Posicion, Edad, Altura, Peso FROM Jugador";
            DataSet ds = oDatos.Leer2(consulta);
            List<Jugador> listaJugadores = new List<Jugador>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    Jugador jugador = new Jugador(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        fila["Apellido"].ToString(),
                        fila["DNI"].ToString(),
                        fila["Telefono"].ToString(),
                        Convert.ToDateTime(fila["FechaNacimiento"]),
                        fila["Posicion"].ToString(),
                        Convert.ToInt32(fila["Edad"]),
                        Convert.ToInt32(fila["Altura"]),
                        Convert.ToInt32(fila["Peso"]),
                        null, // Equipo se asignará después
                        null, // Partidos se asignarán después
                        null  // Convocatorias se asignarán después
                    );

                    listaJugadores.Add(jugador);
                }
            }
            return listaJugadores;
        }

        public bool Guardar(Jugador jugador)
        {
            string consultaSQL;
            if (jugador.Id != 0)
            {
                consultaSQL = $"UPDATE Jugador SET Nombre = '{jugador.Nombre}', Apellido = '{jugador.Apellido}', DNI = '{jugador.DNI}', Telefono = '{jugador.Telefono}', FechaNacimiento = '{jugador.FechaNacimiento:yyyy-MM-dd}', Posicion = '{jugador.Posicion}', Edad = {jugador.Edad}, Altura = {jugador.Altura}, Peso = {jugador.Peso} WHERE Id = {jugador.Id}";
            }
            else
            {
                consultaSQL = $"INSERT INTO Jugador (Nombre, Apellido, DNI, Telefono, FechaNacimiento, Posicion, Edad, Altura, Peso) VALUES ('{jugador.Nombre}', '{jugador.Apellido}', '{jugador.DNI}', '{jugador.Telefono}', '{jugador.FechaNacimiento:yyyy-MM-dd}', '{jugador.Posicion}', {jugador.Edad}, {jugador.Altura}, {jugador.Peso})";
            }
            return oDatos.Escribir(consultaSQL);
        }

        public bool Baja(long Id)
        {
            string consultaSQL = $"DELETE FROM Jugador WHERE Id = {Id}";
            return oDatos.Escribir(consultaSQL);
        }

        public Jugador ListarObjeto(long Id)
        {
            string consulta = $"SELECT Id, Nombre, Apellido, DNI, Telefono, FechaNacimiento, Posicion, Edad, Altura, Peso FROM Jugador WHERE Id = {Id}";
            DataSet ds = oDatos.Leer2(consulta);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow fila = ds.Tables[0].Rows[0];
                return new Jugador(
                    Convert.ToInt64(fila["Id"]),
                    fila["Nombre"].ToString(),
                    fila["Apellido"].ToString(),
                    fila["DNI"].ToString(),
                    fila["Telefono"].ToString(),
                    Convert.ToDateTime(fila["FechaNacimiento"]),
                    fila["Posicion"].ToString(),
                    Convert.ToInt32(fila["Edad"]),
                    Convert.ToInt32(fila["Altura"]),
                    Convert.ToInt32(fila["Peso"]),
                    null, // Equipo se asignará después
                    null, // Partidos se asignarán después
                    null  // Convocatorias se asignarán después
                );
            }
            return null;
        }

        public List<Jugador> ListarJugadoresPorEquipo(long equipoId)
        {
            string consulta = $"SELECT Id, Nombre, Apellido, DNI, Telefono, FechaNacimiento, Posicion, Edad, Altura, Peso FROM Jugador WHERE EquipoId = {equipoId}";
            DataSet ds = oDatos.Leer2(consulta);
            List<Jugador> listaJugadores = new List<Jugador>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow fila in ds.Tables[0].Rows)
                {
                    Jugador jugador = new Jugador(
                        Convert.ToInt64(fila["Id"]),
                        fila["Nombre"].ToString(),
                        fila["Apellido"].ToString(),
                        fila["DNI"].ToString(),
                        fila["Telefono"].ToString(),
                        Convert.ToDateTime(fila["FechaNacimiento"]),
                        fila["Posicion"].ToString(),
                        Convert.ToInt32(fila["Edad"]),
                        Convert.ToInt32(fila["Altura"]),
                        Convert.ToInt32(fila["Peso"]),
                        null, // Equipo se asignará después
                        null, // Partidos se asignarán después
                        null  // Convocatorias se asignarán después
                    );

                    listaJugadores.Add(jugador);
                }
            }
            return listaJugadores;
        }

    }
}