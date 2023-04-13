using System;
using System.Collections.Generic;

namespace Oracle.DataAccess.Models;

public partial class Puesto
{
    public int Idpuesto { get; set; }

    public string Nombrepuesto { get; set; } = null!;

    public string? Departamento { get; set; }

    public string? Niveljuridico { get; set; }

    public decimal? Salario { get; set; }

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}
