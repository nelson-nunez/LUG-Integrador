using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Campeonato: ClaseBase
    {
        #region Propiedades

        public string Nombre { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int CantidadPartidos { get; set; }
        public int CantidadJugadores { get; set; }
        public virtual ICollection<Partido> Partidos { get; set; }

        #endregion

        public Campeonato() { }
        public Campeonato(long idCampeonato, string nombre, DateTime fechaInicio, DateTime fechaFin, int cantidadPartidos, int cantidadJugadores, List<Partido> partidos)
        {
            Id = idCampeonato;
            Nombre = nombre;
            FechaInicio = fechaInicio;
            FechaFin = fechaFin;
            CantidadPartidos = cantidadPartidos;
            CantidadJugadores = cantidadJugadores;
            Partidos = partidos ?? new List<Partido>();
        }


        public class PartidoView
        {
            public DateTime Fecha { get; set; }
            public int Duracion { get; set; }
            public int NumeroCancha { get; set; }
            public string Ubicacion { get; set; }
            public string Categoria { get; set; }
        }

        public virtual List<PartidoView> RetornarVista()
        {
            var partidosParaMostrar = Partidos.Select(p => new PartidoView
            {
                Fecha = p.Fecha,
                Duracion = p.Duracion,
                NumeroCancha = p.NumeroCancha,
                Ubicacion = p.Ubicacion,
                Categoria = p.Categoria
            }).ToList();

            return partidosParaMostrar;
        }
    }
}
