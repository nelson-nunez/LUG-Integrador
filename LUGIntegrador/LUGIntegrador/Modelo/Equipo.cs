using LUGIntegrador.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUGIntegrador.Modelo
{
    public class Equipo: ClaseBase
    {
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public virtual ICollection<Jugador> Jugadores { get; set; }

        public Equipo(long idEquipo, string nombre, string descripcion)
        {
            Id = idEquipo;
            Nombre = nombre;
            Descripcion = descripcion;
            Jugadores = new List<Jugador>();
        }
    }
}
