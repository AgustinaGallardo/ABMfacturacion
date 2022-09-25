using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABMfacturacion
{
    internal class FormaPago
    {
        public int IdFormaPago { get; set; }
        public string TipoFP { get; set; }

        public FormaPago()
        {
            this.IdFormaPago = 0;
            this.TipoFP = string.Empty;
            
        }
        public FormaPago(int id,string nombre)
        {
            this.IdFormaPago = id;
            TipoFP = nombre;
        }
    }
}
