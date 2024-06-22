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
        public int KmRecorrido { get; set; }
        public bool TarjetaRoja { get; set; }
        public bool TarjetaAmarilla { get; set; }
        public int Goles { get; set; }
        public int Recuperaciones { get; set; }

        public virtual Jugador Jugador { get; set; }
        public virtual Partido Partido { get; set; }

        public Estadistica() { }
        public Estadistica(long idEstadistica, int pasesConectados, int kmRecorrido, bool tarjetaRoja, bool tarjetaAmarilla, int goles, int recuperaciones, Jugador jugador, Partido partido)
        {
            Id = idEstadistica;
            PasesConectados = pasesConectados;
            KmRecorrido = kmRecorrido;
            TarjetaRoja = tarjetaRoja;
            TarjetaAmarilla = tarjetaAmarilla;
            Goles = goles;
            Recuperaciones = recuperaciones;
            Jugador = jugador ?? new Jugador();
            Partido = partido ?? new Partido();
        }
    }
}
