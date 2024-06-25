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

        #region Constructor

        public Tecnico() { }

        public Tecnico(long id, string nombre, string apellido, string dni, string telefono, DateTime fechaNacimiento, string email, string password,
            string titulo, int nro_licencia, Equipo equipo) : base(id, nombre, apellido, dni, telefono, fechaNacimiento, email, password, "Tecnico")
        {
            Titulo = titulo;
            Nro_licencia = nro_licencia;
            Equipo = equipo ?? new Equipo();
        }

        #endregion
    }
}

