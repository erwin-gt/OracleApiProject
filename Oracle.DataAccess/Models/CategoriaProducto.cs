using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class CategoriaProducto
{
    public int Idcategoriaproducto { get; set; }

    public string Tipomueble { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
