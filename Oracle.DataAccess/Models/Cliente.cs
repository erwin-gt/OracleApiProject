using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NombreDocumento { get; set; }

    public string PrimerNombre { get; set; } = null!;

    public string? SegundoNombre { get; set; }

    public string PrimerApellido { get; set; } = null!;

    public string? SegundoApellido { get; set; }

    public string? TelefonoResidencia { get; set; }

    public string? TelefonoCelular { get; set; }

    public string? Direccion { get; set; }

    public string? CiudadResidencia { get; set; }

    public string? Departamento { get; set; }

    public string? Pais { get; set; }

    public string? Profesion { get; set; }

    public string? Email { get; set; }

    public int? Idusuario { get; set; }

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();

    public virtual Usuario? IdusuarioNavigation { get; set; }
}
