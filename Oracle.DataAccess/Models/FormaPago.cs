using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class FormaPago
{
    public int Idformapago { get; set; }

    public string? Tipopago { get; set; }

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();
}
