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
        public Jugador(long id, string nombre, string apellido, string dni, string telefono, DateTime fechaNacimiento, string email, string password,
            string posicion, int edad, int altura, int peso, Equipo equipo, List<Partido> partidos, List<Convocatoria> convocatorias)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Password = password;

            Posicion = posicion;
            Edad = edad;
            Altura = altura;
            Peso = peso;
            Equipo = equipo ?? new Equipo();
            Partidos = partidos ?? new List<Partido>();
            Convocatorias = convocatorias ?? new List<Convocatoria>();
        }

        public override object RetornarMenu()
        {
            var vista = new
            {

            };
            return vista;
        }

        #endregion
    }
}
