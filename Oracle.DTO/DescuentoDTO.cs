using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class DescuentoDTO
    {
        public int Iddescuento { get; set; }

        public string? TipoDescuento { get; set; }

        public string? CondicionesUso { get; set; }

        public decimal? PorcentajeDescuento { get; set; }

        public decimal? DescuentoCantidad { get; set; }
    }
}
