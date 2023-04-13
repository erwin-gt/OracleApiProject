using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Sucursal
{
    public int Idsucursal { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public string? Numero { get; set; }

    public string? Email { get; set; }

    public int? Idterritorio { get; set; }

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();

    public virtual Territorio? IdterritorioNavigation { get; set; }
}
