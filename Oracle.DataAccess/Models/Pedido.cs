using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Pedido
{
    public int Idpedido { get; set; }

    public DateTime? Fechapedido { get; set; }

    public DateTime? Fechaentrega { get; set; }

    public string? Estadoenvio { get; set; }

    public int? Idfactura { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; } = new List<DetallePedido>();

    public virtual Factura? IdfacturaNavigation { get; set; }
}
