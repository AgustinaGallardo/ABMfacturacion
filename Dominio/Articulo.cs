using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMfacturacion
{
    internal class Articulo
    {
        public int idArticulo { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }
        public bool ProductoActivo { get; set; }

        public Articulo()
        {
            this.idArticulo=0;
            this.Nombre = Nombre;
            this.PrecioUnitario = PrecioUnitario;
            this.ProductoActivo = true;
        }

        public Articulo( int idArticulo, string nombre, double precioUnitario)
        {

            idArticulo = idArticulo;
            Nombre = nombre;
            PrecioUnitario = precioUnitario;
           
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
