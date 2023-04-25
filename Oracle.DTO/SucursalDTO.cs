using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class SucursalDTO
    {
        public int Id { get; set; }

        public string? Nombre { get; set; }

        public string? Direccion { get; set; }

        public string? Numero { get; set; }

        public string? Email { get; set; }

        public int? IdTerritorio { get; set; }
    }
}
