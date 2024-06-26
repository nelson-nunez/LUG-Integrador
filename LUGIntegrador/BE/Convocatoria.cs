﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Convocatoria: ClaseBase
    {
        public string Posicion { get; set; }
        public bool Confirmacion { get; set; }
        public DateTime Fecha { get; set; }
        public TimeSpan Duracion { get; set; }
        public string Ubicacion { get; set; }
        public virtual Jugador Jugador { get; set; }
        public string NombreJugador
        {
            get
            {
                return Jugador != null ? $"{Jugador.Nombre}, {Jugador.Apellido}" : "";
            }
        }
        public virtual Partido Partido { get; set; }

        public Convocatoria() { }
        public Convocatoria(long idConvocatoria, string posicion, bool confirmacion, DateTime fecha, TimeSpan duracion, string ubicacion, Jugador jugador, Partido partido)
        {
            Id = idConvocatoria;
            Posicion = posicion;
            Confirmacion = confirmacion;
            Fecha = fecha;
            Duracion = duracion;
            Ubicacion = ubicacion;
            Jugador = jugador ?? new Jugador();
            Partido = partido ?? new Partido();
        }
    }
}
