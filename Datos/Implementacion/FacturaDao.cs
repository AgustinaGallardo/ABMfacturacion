using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABMfacturacion.Datos.Interfaz;
using System.Data;


namespace ABMfacturacion.Datos.Implementacion
{
    internal class FacturaDao : IdaoFactura
    {
        public int ObetnerProximo()
        {
            string sp_nombre = "ProximaFactura";
            string nombreOutput = "@Next";
            return Helper.ObtenerInstancia().ObtenerProximo(sp_nombre, nombreOutput);
        }

       
    }
}
