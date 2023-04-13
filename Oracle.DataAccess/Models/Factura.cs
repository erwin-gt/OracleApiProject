using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Factura
{
    public int Idfactura { get; set; }

    public DateTime? Fechaemision { get; set; }

    public decimal? Total { get; set; }

    public string? Estadofactura { get; set; }

    public string? Notas { get; set; }

    public int? Idempleado { get; set; }

    public int? Idsucursal { get; set; }

    public int? Idcliente { get; set; }

    public int? Idformapago { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; } = new List<DetalleFactura>();

    public virtual Cliente? IdclienteNavigation { get; set; }

    public virtual Empleado? IdempleadoNavigation { get; set; }

    public virtual FormaPago? IdformapagoNavigation { get; set; }

    public virtual Sucursal? IdsucursalNavigation { get; set; }

    public virtual ICollection<Pedido> Pedidos { get; } = new List<Pedido>();
}
