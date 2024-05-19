using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class Partido: ClaseBase
    {
        public DateTime Fecha { get; set; }
        public int Duracion { get; set; }
        public int NumeroCancha { get; set; }
        public string Ubicacion { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<Estadistica> Estadisticas { get; set; }
        public virtual ICollection<Convocatoria> Convocatorias { get; set; }

        public Partido(long idPartido, DateTime fecha, int duracion, int numeroCancha, string ubicacion, string categoria)
        {
            Id = idPartido;
            Fecha = fecha;
            Duracion = duracion;
            NumeroCancha = numeroCancha;
            Ubicacion = ubicacion;
            Categoria = categoria;
            Estadisticas = new List<Estadistica>();
            Convocatorias = new List<Convocatoria>();
        }
    }
}
