using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Usuario
{
    public int Idusuario { get; set; }

    public string? Contraseña { get; set; }

    public string? Email { get; set; }

    public string? Permisos { get; set; }

    public string? Rol { get; set; }

    public string? Status { get; set; }

    public int? Idtipousuario { get; set; }

    public virtual ICollection<Cliente> Clientes { get; } = new List<Cliente>();

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();

    public virtual TipoUsuario? IdtipousuarioNavigation { get; set; }
}
