using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class ClienteDTO
    {
        public int Idcliente { get; set; }

        public string? TipoDoc { get; set; }

        public string? NameDoc { get; set; }

        public string PNombre { get; set; } = null!;

        public string? SNombre { get; set; }

        public string PApellido { get; set; } = null!;

        public string? SApellido { get; set; }

        public string? TelResidencia { get; set; }

        public string? TelCelular { get; set; }

        public string? Direccion { get; set; }

        public string? Ciudad { get; set; }

        public string? Departamento { get; set; }

        public string? Pais { get; set; }

        public string? Profesion { get; set; }

        public string? Email { get; set; }

        public int? Idusuario { get; set; }
    }
}
