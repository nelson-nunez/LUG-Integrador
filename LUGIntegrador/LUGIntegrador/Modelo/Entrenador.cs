using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUGIntegrador.Modelo
{
    public class Entrenador : Persona
    {
        public string NumeroLicencia { get; set; }
        public string Titulo { get; set; }

        public Entrenador(long id, string nombre, string apellido, string dni, string telefono, DateTime fechaNacimiento, string numeroLicencia, string titulo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;

            NumeroLicencia = numeroLicencia;
            Titulo = titulo;
        }
    }
}
