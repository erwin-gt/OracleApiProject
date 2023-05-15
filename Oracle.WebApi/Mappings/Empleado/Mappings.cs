using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperEmp
    {
        public static EmpleadoDTO ToDTO(this Empleado model)
        {
            return new EmpleadoDTO
            {
                Idempleado = model.Idempleado,
                PrimerNombre = model.PrimerNombre,
                SegundoNombre = model.SegundoNombre,
                PrimerApellido = model.PrimerApellido,
                SegundoApellido = model.SegundoApellido,
                Dpi = model.Dpi,
                Edad = model.Edad,
                Direccion = model.Direccion,
                Email = model.Email,
                Telefono = model.Telefono,
                Sexo = model.Sexo,
                Fechacontratacion = model.Fechacontratacion,
                Salario = model.Salario,
                Idsucursal = model.Idsucursal,
                Idpuesto = model.Idsucursal,
                Idusuario = model.Idsucursal,
            };
        }
    }

    public static partial class MapperEmp
    {
        public static Empleado ToDatabase(this EmpleadoDTO dto)
        {
            return new Empleado()
            {
                Idempleado = dto.Idempleado,
                PrimerNombre = dto.PrimerNombre,
                SegundoNombre = dto.SegundoNombre,
                PrimerApellido = dto.PrimerApellido,
                SegundoApellido = dto.SegundoApellido,
                Dpi = dto.Dpi,
                Edad = dto.Edad,
                Direccion = dto.Direccion,
                Email = dto.Email,
                Telefono = dto.Telefono,
                Sexo = dto.Sexo,
                Fechacontratacion = dto.Fechacontratacion,
                Salario = dto.Salario,
                Idsucursal = dto.Idsucursal,
                Idpuesto = dto.Idsucursal,
                Idusuario = dto.Idsucursal,
            };
        }
    }
}
