using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }

        public string? Pass { get; set; }

        public string? Email { get; set; }

        public string? Permisos { get; set; }

        public string? Rol { get; set; }

        public string? Status { get; set; }

        public int? TipoUser { get; set; }
    }
}
