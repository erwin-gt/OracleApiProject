using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Empleado
{
    public int Idempleado { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public string Dpi { get; set; } = null!;

    public byte? Edad { get; set; }

    public string? Direccion { get; set; }

    public string? Email { get; set; }

    public string? Telefono { get; set; }

    public string? Sexo { get; set; }

    public DateTime? Fechacontratacion { get; set; }

    public decimal? Salario { get; set; }

    public byte? Evaluaciondesempeno { get; set; }

    public int? Idsucursal { get; set; }

    public int? Idpuesto { get; set; }

    public int? Idusuario { get; set; }

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();

    public virtual Puesto? IdpuestoNavigation { get; set; }

    public virtual Sucursal? IdsucursalNavigation { get; set; }

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
