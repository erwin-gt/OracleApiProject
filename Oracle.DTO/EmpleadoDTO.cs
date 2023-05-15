using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class EmpleadoDTO
    {
        public int Idempleado { get; set; }

        public string PrimerNombre { get; set; } = null!;

        public string? SegundoNombre { get; set; }

        public string PrimerApellido { get; set; } = null!;

        public string? SegundoApellido { get; set; }

        public string Dpi { get; set; } = null!;

        public byte? Edad { get; set; }

        public string? Direccion { get; set; }

        public string? Email { get; set; }

        public string? Telefono { get; set; }

        public string? Sexo { get; set; }

        public DateTime? Fechacontratacion { get; set; }

        public decimal? Salario { get; set; }

        public byte? Evaluaciondesempeno { get; set; }

        public int? Idsucursal { get; set; }

        public int? Idpuesto { get; set; }

        public int? Idusuario { get; set; }
    }
}
