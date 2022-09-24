using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMfacturacion
{
    internal class Articulo
    {
        public int IdArticulo { get; set; }
        public string Nombre { get; set; }
        public double PrecioUnitario { get; set; }
        public bool ProductoActivo { get; set; }

        public Articulo()
        {
            this.IdArticulo=0;
            this.Nombre = Nombre;
            this.PrecioUnitario = PrecioUnitario;
            this.ProductoActivo = true;
        }

        public Articulo( int idArticulo, string nombre, double precioUnitario)
        {

            this.IdArticulo = idArticulo;
            this.Nombre = nombre;
            this.PrecioUnitario = precioUnitario;
           
        }

        public override string ToString()
        {
            return Nombre;
        }
    }
}
