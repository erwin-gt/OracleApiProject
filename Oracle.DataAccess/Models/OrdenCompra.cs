using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class OrdenCompra
{
    public int Idordencompra { get; set; }

    public DateTime Fechacompra { get; set; }

    public int Cantidad { get; set; }

    public string Ubicacion { get; set; } = null!;

    public int Idproveedor { get; set; }

    public int Idproducto { get; set; }

    public decimal Preciounitario { get; set; }

    public virtual Proveedor IdproveedorNavigation { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
