using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMfacturacion.Datos.Interfaz
{
    internal interface IdaoFactura
    {
        int ObetnerProximo();
        List<FormaPago> ObtenerTodos();
    }
}
