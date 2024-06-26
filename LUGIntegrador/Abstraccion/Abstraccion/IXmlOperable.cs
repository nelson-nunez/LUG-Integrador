using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraccion
{
    public interface IXmlOperable<T>
    {
        bool Existe(T item);
        bool CrearArchivo(List<T> lista);
        List<T> LeerArchivo();
        void AgregarLinea(T item);
        void BorrarLinea(T item);
    }
}
