using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class TerritorioDTO
    {
        public int Idterritorio { get; set; }

        public string? Nombre { get; set; }

        public string? Descripcion { get; set; }

        public int? Region { get; set; }

        //public virtual Region? IdregionNavigation { get; set; }
    }
}
