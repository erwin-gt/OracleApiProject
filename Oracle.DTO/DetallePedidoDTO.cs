using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class DetallePedidoDTO
    {
        public int IddetallePedido { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Preciounitario { get; set; }

        public decimal? Descuento { get; set; }

        public decimal? Subtotal { get; set; }

        public int? Idpedido { get; set; }

        public int? Idproducto { get; set; }
    }
}
