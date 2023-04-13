using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class TipoUsuario
{
    public int Idtipousuario { get; set; }

    public string? NombreTipoUsuario { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; } = new List<Usuario>();
}
