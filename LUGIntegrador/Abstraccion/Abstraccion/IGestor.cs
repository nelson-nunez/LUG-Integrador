using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IGestor<T> where T : IEntidad
    {
        bool Guardar(T Objeto);
        bool Baja(long Id);
        List<T> ListarTodo(bool include);
        T ListarObjeto(long Id);
    }
}
