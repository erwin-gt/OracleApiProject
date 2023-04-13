using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Region
{
    public int Idregion { get; set; }

    public string? Nombre { get; set; }

    public string? Ciudad { get; set; }

    public string? Provincia { get; set; }

    public virtual ICollection<Territorio> Territorios { get; } = new List<Territorio>();
}
