using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class DetalleFacturaDTO
    {
        public int Iddetallefactura { get; set; }

        public int? Cantidad { get; set; }

        public decimal? Preciounitario { get; set; }

        public decimal? Totaldetalle { get; set; }

        public int? Iddescuento { get; set; }

        public int? Idfactura { get; set; }
    }
}
