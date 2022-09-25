using ABMfacturacion.Datos.Implementacion;
using ABMfacturacion.Datos.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMfacturacion.Servicios
{
    internal class Servicio : iServicio
    {
        private IdaoFactura dao;

        public Servicio()
        {
            dao = new FacturaDao();
        }
        public int ObtenerProximo()
        {
            return dao.ObetnerProximo();
        }

        public List<FormaPago> ObtenerTodos()
        {
            return dao.ObtenerTodos();
        }
    }
}
