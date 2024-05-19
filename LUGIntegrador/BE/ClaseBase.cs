using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;

namespace BE
{
    //Abst para q no se pueda instanciar directamente
    public abstract class ClaseBase: IEntidad
    {
        public long Id { get; set; }
    }
}
