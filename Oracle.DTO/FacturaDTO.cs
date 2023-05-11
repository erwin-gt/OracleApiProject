using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class FacturaDTO
    {
        public int Idfactura { get; set; }

        public DateTime? Fechaemision { get; set; }

        public decimal? Total { get; set; }

        public string? Estadofactura { get; set; }

        public string? Notas { get; set; }

        public int? Idempleado { get; set; }

        public int? Idcliente { get; set; }

        public int? Idformapago { get; set; }
    }
}
