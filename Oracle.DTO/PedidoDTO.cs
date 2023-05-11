using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class PedidoDTO
    {
        public int Idpedido { get; set; }

        public DateTime? Fechapedido { get; set; }

        public DateTime? Fechaentrega { get; set; }

        public string? Estadoenvio { get; set; }

        public int? Idfactura { get; set; }

    }
}
