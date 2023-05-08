using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class CardexDTO
    {
        public int Idinventario { get; set; }

        public string? Descripcion { get; set; }

        public int Cantidad { get; set; }

        public decimal Preciounitario { get; set; }

        public decimal Valortotal { get; set; }

        public DateTime Registro { get; set; }

        public DateTime Actualizacion { get; set; }

        public string Nserie { get; set; } = null!;

        public string Almacen { get; set; } = null!;

        public string? Observaciones { get; set; }

        
    }
}
