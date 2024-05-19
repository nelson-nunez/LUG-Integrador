using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Estadistica: ClaseBase
    {
        public int PasesConectados { get; set; }
        public int PasesFallados { get; set; }
        public int Asistencias { get; set; }
        public int KmRecorrido { get; set; }
        public bool TarjetaRoja { get; set; }
        public bool TarjetaAmarilla { get; set; }
        public int DuelosGanados { get; set; }
        public int DuelosPerdidos { get; set; }
        public int Bloqueos { get; set; }
        public int Disparos { get; set; }
        public int Goles { get; set; }
        public int Recuperaciones { get; set; }

        public long JugadorId { get; set; }
        public virtual Jugador Jugador { get; set; }
        public long PartidoId { get; set; }
        public virtual Partido Partido { get; set; }

        public Estadistica(long idEstadistica, int pasesConectados, int pasesFallados, int asistencias, int kmRecorrido, bool tarjetaRoja, bool tarjetaAmarilla, int duelosGanados, int duelosPerdidos, int bloqueos, int disparos, int goles, int recuperaciones, Jugador jugador, Partido partido)
        {
            Id = idEstadistica;
            PasesConectados = pasesConectados;
            PasesFallados = pasesFallados;
            Asistencias = asistencias;
            KmRecorrido = kmRecorrido;
            TarjetaRoja = tarjetaRoja;
            TarjetaAmarilla = tarjetaAmarilla;
            DuelosGanados = duelosGanados;
            DuelosPerdidos = duelosPerdidos;
            Bloqueos = bloqueos;
            Disparos = disparos;
            Goles = goles;
            Recuperaciones = recuperaciones;
            Jugador = jugador;
            Partido = partido;
            JugadorId = jugador.Id;
            PartidoId = partido.Id;
        }
    }
}
