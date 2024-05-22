using Abstraccion;
using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BLLPartido : IGestor<Partido>
    {
        private MPPPartido oMPPPartido;

        public BLLPartido()
        {
            oMPPPartido = new MPPPartido();
        }

        public List<Partido> ListarTodo()
        {
            return oMPPPartido.ListarTodo();
        }

        public bool Guardar(Partido Partido)
        {
            return oMPPPartido.Guardar(Partido);
        }

        public bool Baja(long Id)
        {
            return oMPPPartido.Baja(Id);
        }

        public Partido ListarObjeto(long Id)
        {
            return oMPPPartido.ListarObjeto(Id);
        }
    }
}
