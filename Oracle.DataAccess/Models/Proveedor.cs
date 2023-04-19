using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Proveedor
{
    public int Idproveedor { get; set; }

    public string Nombreempresa { get; set; } = null!;

    public string Contacto { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Email { get; set; } = null!;

   public virtual ICollection<OrdenCompra> OrdenCompras { get; } = new List<OrdenCompra>();
}
