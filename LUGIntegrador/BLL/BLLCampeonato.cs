using Abstraccion;
using BE;
using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion.Extensiones;
using UI_LUGIntegrador.Extensiones;

namespace BLL
{
    public class BLLCampeonato : IGestor<Campeonato>
    {
        private MPPCampeonato oMPPCampeonato;

        public BLLCampeonato()
        {
            oMPPCampeonato = new MPPCampeonato();
        }

        public List<Campeonato> ListarTodo()
        {
            return oMPPCampeonato.ListarTodo();
        }

        public List<Campeonato> ListarTodoConFixture()
        {
            var list = oMPPCampeonato.ListarTodo();

            return list.Where(X=>X.Partidos.IsNOTNullOrEmpty()).ToList();
        }

        public bool Guardar(Campeonato campeonato)
        {
            var item = ListarObjeto(campeonato.Id);
            if (campeonato.Partidos.IsNOTNullOrEmpty() && item!= null && item.Partidos.IsNOTNullOrEmpty())
                throw new Exception("No se puede editar porque ya se generó el fixture."); 
            
            return oMPPCampeonato.Guardar(campeonato);
        }

        public bool GuardarGenerandoFixture(Campeonato campeonato)
        {
            var item = ListarObjeto(campeonato.Id);
            if (campeonato.Partidos.IsNOTNullOrEmpty() && item.Partidos.IsNOTNullOrEmpty())
                throw new Exception("No se puede generar fixture porque ya existe uno vigente."); 

            // Calcular cantidad de días entre FechaInicio y FechaFin
            int cantidadDias = (campeonato.FechaFin - campeonato.FechaInicio).Days;

            // Generar partidos
            Random random = new Random();
            campeonato.Partidos = new List<Partido>();

            for (int i = 0; i < campeonato.CantidadPartidos; i++)
            {
                DateTime fecha = campeonato.FechaInicio.AddDays(cantidadDias * i / campeonato.CantidadPartidos);
                Partido partido = new Partido
                {
                    Fecha = fecha,
                    Duracion = 90, // Duración en minutos
                    NumeroCancha = random.Next(1, 6), // Número de cancha aleatorio entre 1 y 5
                    Ubicacion = $"Club {random.Next(1, 6)}", // Ubicación aleatoria (Club 1 a 5)
                    Categoria = campeonato.CantidadJugadores < 6 ? "Fútbol 5" : "Fútbol 11",
                    Campeonato = campeonato
                };

                campeonato.Partidos.Add(partido);
            }

            // Guardar campeonato
            return oMPPCampeonato.Guardar(campeonato);
        }

        public bool Baja(long Id)
        {
            return oMPPCampeonato.Baja(Id);
        }

        public Campeonato ListarObjeto(long Id)
        {
            return oMPPCampeonato.ListarObjeto(Id);
        }
    }
}

