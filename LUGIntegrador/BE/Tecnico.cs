using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Tecnico : Persona
    {
        #region Propiedades

        public string Titulo { get; set; }
        public int Nro_licencia { get; set; }
        public virtual Equipo Equipo { get; set; }

        #endregion

        #region Metodos
        public Tecnico() { }
        public Tecnico(long id, string nombre, string apellido, string dni, string telefono, DateTime fechaNacimiento, string email, string password,
            string titulo, int nro_licencia, Equipo equipo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Password = password;

            Titulo = telefono;
            Nro_licencia = nro_licencia;
            Equipo = equipo ?? new Equipo();
        }

        public override object RetornarMenu()
        {
            var vista = new
            {
                //Convocatorias,
                //Estadisticas,
                //Partidos,
            };
            return vista;
        }

        #endregion
    }
}

