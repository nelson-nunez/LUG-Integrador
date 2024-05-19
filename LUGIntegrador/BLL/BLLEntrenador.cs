﻿using MPP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstraccion;
using BE;

namespace BLL
{
    public class BLLEntrenador : IGestor<Entrenador>
    {
        private MPPEntrenador oMPPEntrenador;

        public BLLEntrenador()
        {
            oMPPEntrenador = new MPPEntrenador();
        }

        public List<Entrenador> ListarTodo()
        {
            return oMPPEntrenador.ListarTodo();
        }

        public bool Guardar(Entrenador entrenador)
        {
            return oMPPEntrenador.Guardar(entrenador);
        }

        public bool Baja(Entrenador entrenador)
        {
            return oMPPEntrenador.Baja(entrenador);
        }

        public Entrenador ListarObjeto(Entrenador entrenador)
        {
            return oMPPEntrenador.ListarObjeto(entrenador);
        }
    }
}