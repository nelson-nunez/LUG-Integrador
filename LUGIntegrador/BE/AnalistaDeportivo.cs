using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class AnalistaDeportivo : Persona
    {
        #region Propiedades

        public string IdAnalista { get; set; }
        public string Matricula { get; set; }

        #endregion

        #region Metodos
        
        public AnalistaDeportivo(long id, string nombre, string apellido, string dni, string telefono, DateTime fechaNacimiento,  string matricula)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;

            Matricula = matricula;
        }

        public override object RetornarVista()
        {
            var vista = new
            {
                Nombre = this.Nombre,
                Apellido = this.Apellido,
                Matricula = this.Matricula,
            };
            return vista;
        }

        #endregion
    }
}
