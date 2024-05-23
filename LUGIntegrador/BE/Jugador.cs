using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Jugador : Persona
    {
        #region Propiedades

        public string Posicion { get; set; }
        public int Edad { get; set; }
        public int Altura { get; set; }
        public int Peso { get; set; }
        public virtual Equipo Equipo { get; set; }
        public virtual ICollection<Partido> Partidos { get; set; }
        public virtual ICollection<Convocatoria> Convocatorias { get; set; }

        #endregion

        #region Metodos
        public Jugador() { }
        public Jugador(long id, string nombre, string apellido, string dni, string telefono, DateTime fechaNacimiento, string posicion, int edad, int altura, int peso, Equipo equipo, List<Partido> partidos, List<Convocatoria> convocatorias)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;

            Posicion = posicion;
            Edad = edad;
            Altura = altura;
            Peso = peso;
            Equipo = equipo ?? new Equipo();
            Partidos = partidos ?? new List<Partido>();
            Convocatorias = convocatorias ?? new List<Convocatoria>();
        }

        public override object RetornarVista()
        {
            var vista = new
            {
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                DNI = this.DNI,
                Posicion = this.Posicion,
                Edad = this.Edad
            };
            return vista;
        }

        #endregion
    }
    public class JugadorView
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Posicion { get; set; }
        public int Edad { get; set; }
        public int Altura { get; set; }
        public int Peso { get; set; }
        public JugadorView(string nombre, string apellido, string dni,string posicion, int edad, int altura, int peso)
        {
            Nombre= nombre;
            Apellido= apellido;
            DNI=dni;
            Posicion=posicion;
            Edad = edad;
            Altura= altura;
            Peso= peso;
        }
    }
}
