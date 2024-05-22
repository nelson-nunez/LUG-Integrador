using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BE;
using MPP;
using Abstraccion;
using UI_LUGIntegrador.Extensiones;

namespace BLL
{
    public class BLLConvocatoria : IGestor<Convocatoria>
    {
        private MPPConvocatoria oMPPConvocatoria;
        private MPPJugador mppjugador;
        public BLLConvocatoria()
        {
            oMPPConvocatoria = new MPPConvocatoria();
            mppjugador = new MPPJugador();
        }

        public List<Convocatoria> ListarTodo()
        {
            return oMPPConvocatoria.ListarTodo();
        }

        public bool Guardar(Convocatoria convocatoria)
        {
            return oMPPConvocatoria.Guardar(convocatoria);
        }

        public bool GenerarConvocatoriasParaPartido(Partido partido, Equipo equipo)
        {
            var jugadores = mppjugador.ListarJugadoresPorEquipo(equipo.Id);
            if (jugadores.IsNOTNullOrEmpty())
            {
                foreach (var item in jugadores)
                {
                    var convocatoria = new Convocatoria(0, item.Posicion, false, DateTime.Now, TimeSpan.Zero, partido.Ubicacion, item, partido);
                    oMPPConvocatoria.Guardar(convocatoria);
                }
                return true;
            }
            else
                return false;
        }

        public bool Baja(long Id)
        {
            return oMPPConvocatoria.Baja(Id);
        }

        public Convocatoria ListarObjeto(long Id)
        {
            return oMPPConvocatoria.ListarObjeto(Id);
        }
    }
}


