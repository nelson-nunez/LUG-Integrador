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
        private MPPPartido oMPPPartido;
        public BLLConvocatoria()
        {
            oMPPConvocatoria = new MPPConvocatoria();
            oMPPPartido = new MPPPartido();
        }

        public List<Convocatoria> ListarTodo(bool include)
        {
            return oMPPConvocatoria.ListarTodo(include);
        }

        public bool Guardar(Convocatoria convocatoria)
        {
            return oMPPConvocatoria.Guardar(convocatoria);
        }

        public bool GenerarConvocatoriasParaPartido(Partido partido, Equipo equipo)
        {
            var game = oMPPConvocatoria.ListarConFiltros(0,equipo.Id, 0, partido.Id);
            if (game.Count() > 0)
                throw new Exception("Ya existe una convocatoria para el partido");
            return oMPPConvocatoria.CrearConvocatorias(partido, equipo);
        }

        public bool Baja(long Id)
        {
            return oMPPConvocatoria.Baja(Id);
        }

        public Convocatoria ListarObjeto(long Id)
        {
            return oMPPConvocatoria.ListarObjeto(Id);
        }

        public List<Convocatoria> ListarConFiltros(Campeonato campeonato, Equipo equipo, Jugador jugador, Partido partido)
        {
            var lista = oMPPConvocatoria.ListarConFiltros(campeonato?.Id, equipo?.Id, jugador?.Id, partido?.Id);
            return lista;
        }
    }
}


