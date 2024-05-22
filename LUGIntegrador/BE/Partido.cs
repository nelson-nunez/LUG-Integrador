using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Partido: ClaseBase
    {
        public DateTime Fecha { get; set; }
        public int Duracion { get; set; }
        public int NumeroCancha { get; set; }
        public string Ubicacion { get; set; }
        public string Categoria { get; set; }
        public virtual Campeonato Campeonato { get; set; }
        public virtual ICollection<Jugador> Jugadores { get; set; }
        public virtual ICollection<Convocatoria> Convocatorias { get; set; }

        public Partido  () { }  
        public Partido(long idPartido, DateTime fecha, int duracion, int numeroCancha, string ubicacion, string categoria, Campeonato campeonato, List<Jugador> jugadores, List<Convocatoria> convocatorias)
        {
            Id = idPartido;
            Fecha = fecha;
            Duracion = duracion;
            NumeroCancha = numeroCancha;
            Ubicacion = ubicacion;
            Categoria = categoria;
            Campeonato = campeonato;
            Jugadores = jugadores ?? new List<Jugador>();
            Convocatorias = convocatorias ?? new List<Convocatoria>();
        }
    }
}
