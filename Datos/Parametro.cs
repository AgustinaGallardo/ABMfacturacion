using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMfacturacion.Datos
{
    internal class Parametro
    {
        public String Clave { get; set; }
        public object Valor { get; set; }   

        public Parametro(string clave, object valor)
        {
            this.Clave = clave;
            this.Valor = valor;
        }
    }
}
