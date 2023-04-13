using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Territorio
{
    public int Idterritorio { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public int? Idregion { get; set; }

    public virtual Region? IdregionNavigation { get; set; }

    public virtual ICollection<Sucursal> Sucursals { get; } = new List<Sucursal>();
}
