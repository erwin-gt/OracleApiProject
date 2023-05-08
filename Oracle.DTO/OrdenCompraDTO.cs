using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class OrdenCompraDTO
    {
        public int Idordencompra { get; set; }

        public DateTime Fechacompra { get; set; }

        public int Cantidad { get; set; }

        public string? Ubicacion { get; set; } 

        public int Idproveedor { get; set; }

        public int Idproducto { get; set; }

        public decimal Preciounitario { get; set; }
    }
}
