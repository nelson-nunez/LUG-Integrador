using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Persona : ClaseBase
    {
        #region Propiedades

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Tipo { get; set; }

        #endregion

        public Persona() { }
        public Persona(long id, string nombre, string apellido, string dni, string telefono, DateTime fechaNacimiento, string email, string password, string tipo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Telefono = telefono;
            FechaNacimiento = fechaNacimiento;
            Email = email;
            Password = password;
            Tipo = tipo;
        }
    }
}
