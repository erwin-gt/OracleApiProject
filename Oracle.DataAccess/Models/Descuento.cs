using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Descuento
{
    public int Iddescuento { get; set; }

    public string? TipoDescuento { get; set; }

    public string? CondicionesUso { get; set; }

    public decimal? PorcentajeDescuento { get; set; }

    public decimal? DescuentoCantidad { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; } = new List<DetalleFactura>();
}
