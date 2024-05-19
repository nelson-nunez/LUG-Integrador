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


        #endregion

        #region Metodos

        public abstract object RetornarVista();
       
        #endregion

    }
}
