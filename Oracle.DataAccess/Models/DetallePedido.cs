using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class DetallePedido
{
    public int IddetallePedido { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Preciounitario { get; set; }

    public decimal? Descuento { get; set; }

    public decimal? Subtotal { get; set; }

    public int? Idpedido { get; set; }

    public virtual Pedido? IdpedidoNavigation { get; set; }
}
