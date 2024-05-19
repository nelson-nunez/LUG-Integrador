using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LUGIntegrador.Base
{
    public abstract class ClaseBase
    {
        //Abst para q no se pueda instanciar directamente
        public long Id { get; set; }
    }
}
