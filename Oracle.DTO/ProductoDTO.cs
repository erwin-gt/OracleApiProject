using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class ProductoDTO
    {
        public int Idproducto { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public string? Color { get; set; }

        public string? Dimensiones { get; set; }

        public byte[]? Foto { get; set; }

        public decimal? Precio { get; set; }

        public int? IdDetalle { get; set; }

        public int? Idinventario { get; set; }

        public int? IdCategoria { get; set; }

        
    }
}
