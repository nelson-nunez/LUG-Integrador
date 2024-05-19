using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace LUGIntegrador.Modelo
{
    public class Jugador : Persona
    {
        public string Posicion { get; set; }
        public int Edad { get; set; }
        public int Altura { get; set; }
        public int Peso { get; set; }

        public virtual ICollection<Estadistica> Estadisticas { get; set; }
        public virtual ICollection<Convocatoria> Convocatorias { get; set; }
        public virtual Equipo Equipo { get; set; }

        public Jugador(long id, string nombre, string apellido, string dni, string telefono, DateTime fechaNacimiento, string posicion, int edad, int altura, int peso)
        {
            Id = id;
            Nombre=nombre;  
            Apellido=apellido;
            DNI= dni;
            Telefono = telefono;
            FechaNacimiento= fechaNacimiento;
           
            Posicion = posicion;
            Edad = edad;
            Altura = altura;
            Peso = peso;
            Estadisticas = new List<Estadistica>();
            Convocatorias = new List<Convocatoria>();
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
    }
}
