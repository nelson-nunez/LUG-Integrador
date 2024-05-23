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
    public class BLLJugador : IGestor<Jugador>
    {
        private MPPJugador oMPPJugador;

        public BLLJugador()
        {
            oMPPJugador = new MPPJugador();
        }

        public List<Jugador> ListarTodo(bool include)
        {
            return oMPPJugador.ListarTodo(include);
        }

        public bool Guardar(Jugador jugador)
        {
            return oMPPJugador.Guardar(jugador);
        }

        public bool Baja(long Id)
        {
            return oMPPJugador.Baja(Id);
        }

        public Jugador ListarObjeto(long Id)
        {
            return oMPPJugador.ListarObjeto(Id);
        }

        public List<JugadorView> ListarJugadoresDisponibles()
        {
            return oMPPJugador.ListarJugadoresDisponibles();
        }

        public List<JugadorView> ListarJugadoresPorEquipo(long equipoId)
        {
            return oMPPJugador.ListarJugadoresViewPorEquipo(equipoId);
        }
    }
}
