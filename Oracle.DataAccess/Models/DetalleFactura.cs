using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class DetalleFactura
{
    public int Iddetallefactura { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Preciounitario { get; set; }

    public decimal? Totaldetalle { get; set; }

    public int? Iddescuento { get; set; }

    public int? Idfactura { get; set; }

    public virtual Descuento? IddescuentoNavigation { get; set; }

    public virtual Factura? IdfacturaNavigation { get; set; }
}
