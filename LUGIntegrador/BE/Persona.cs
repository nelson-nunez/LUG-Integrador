using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    //Abst para q no se pueda instanciar directamente
    public abstract class Persona: ClaseBase
    {
        #region Propiedades

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        #endregion

        #region Metodos

        public abstract object RetornarMenu();
       
        #endregion

    }

    public class PersonaView
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string DNI { get; set; }
        public string Telefono { get; set; }
        public string Tipo { get; set; }
        public PersonaView(long id, string nombre, string apellido, string dni, string telefono, string tipo)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
            Telefono = telefono;
            Tipo = tipo;
        }
    }
}
