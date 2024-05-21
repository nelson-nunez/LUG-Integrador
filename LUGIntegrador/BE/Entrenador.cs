using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Entrenador : Persona
    {
        #region Propiedades
        public string NumeroLicencia { get; set; }
        public string Titulo { get; set; }
        public virtual Equipo Equipo { get; set; }

        #endregion

        #region Metodos

        public Entrenador() { }
        public Entrenador(long id, string nombre, string apellido, string dni, string telefono, DateTime fechaNacimiento, string numeroLicencia, string titulo, Equipo equipo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;

            NumeroLicencia = numeroLicencia;
            Titulo = titulo;
            Equipo = equipo ?? new Equipo();
        }

        public override object RetornarVista()
        {
            var vista = new
            {
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                NumeroLicencia = this.NumeroLicencia,
                Titulo = this.Titulo
            };
            return vista;
        }

        #endregion
    }
}
