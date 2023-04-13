using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Cardex
{
    public int Idinventario { get; set; }

    public string? Descripcion { get; set; }

    public int Cantidad { get; set; }

    public decimal Preciounitario { get; set; }

    public decimal Valortotal { get; set; }

    public DateTime Fecharegistro { get; set; }

    public DateTime Fechaultimaactualizacion { get; set; }

    public string Numeroserie { get; set; } = null!;

    public string Almacen { get; set; } = null!;

    public string? Observaciones { get; set; }

    public virtual ICollection<Producto> Productos { get; } = new List<Producto>();
}
