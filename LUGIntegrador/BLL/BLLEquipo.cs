using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Abstraccion;

namespace BLL
{
    public class BLLEquipo : IGestor<Equipo>
    {
        private MPPEquipo oMPPEquipo;

        public BLLEquipo()
        {
            oMPPEquipo = new MPPEquipo();
        }

        public List<Equipo> ListarTodo(bool include)
        {
            return oMPPEquipo.ListarTodo(include);
        }

        public bool Guardar(Equipo equipo)
        {
            return oMPPEquipo.Guardar(equipo);
        }

        public bool Baja(long Id)
        {
            return oMPPEquipo.Baja(Id);
        }

        public Equipo ListarObjeto(long Id)
        {
            return oMPPEquipo.ListarObjeto(Id);
        }

        public bool EliminarJugador(long equipoId, long jugadorId)
        {
            return oMPPEquipo.EliminarJugadordeEquipo(equipoId, jugadorId);
        }
        
        public bool AñadirJugador(long equipoId, long jugadorId)
        {
            return oMPPEquipo.AñadirJugadorAEquipo(equipoId, jugadorId);
        }
    }
}
