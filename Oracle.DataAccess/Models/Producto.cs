using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public string? Color { get; set; }

    public string? Dimensiones { get; set; }

    public byte[]? Foto { get; set; }

    public decimal? Precio { get; set; }

    public int? Idordencompra { get; set; }

    public int? Idinventario { get; set; }

    public int? Idcategoriaproducto { get; set; }

    public virtual ICollection<DetallePedido> DetallePedidos { get; } = new List<DetallePedido>();

    public virtual CategoriaProducto? IdcategoriaproductoNavigation { get; set; }

    public virtual Cardex? IdinventarioNavigation { get; set; }

    public virtual OrdenCompra? IdordencompraNavigation { get; set; }
}
