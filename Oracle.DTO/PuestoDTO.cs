using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class PuestoDTO
    {
        public int Idpuesto { get; set; }

        public string? Nombrepuesto { get; set; }

        public string? Departamento { get; set; }

        public string? Niveljuridico { get; set; }

        public decimal? Salario { get; set; }
    }
}
