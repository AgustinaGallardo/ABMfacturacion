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

        public List<FormaPago> ObtenerTodos()
        {
            List<FormaPago> list = new List<FormaPago>();
            string sp = "sp_CargarCombo";
            DataTable tabla = Helper.ObtenerInstancia().ObtenerTodos(sp, null);
            foreach (DataRow dr in tabla.Rows)
            {
                int id = int.Parse(dr["id_formapago"].ToString());
                string forma = dr["formaPago"].ToString();
                FormaPago aux = new FormaPago(id, forma);
                list.Add(aux);
            }
            return list;

        }
    }
}
