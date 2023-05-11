using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{

    public static partial class MapperCli
    {
        public static ClienteDTO ToDTO(this Cliente model)
        {
            return new ClienteDTO
            {
                Idcliente = model.Idcliente,
                TipoDoc = model.TipoDocumento,
                NameDoc = model.NombreDocumento,
                PNombre = model.PrimerNombre,
                SNombre = model.SegundoNombre,
                PApellido = model.PrimerApellido,
                SApellido = model.SegundoApellido,
                TelResidencia = model.TelefonoResidencia,
                TelCelular = model.TelefonoCelular,
                Direccion = model.Direccion,
                Ciudad = model.CiudadResidencia,
                Departamento = model.Departamento,
                Pais = model.Pais,
                Profesion = model.Profesion,
                Email = model.Email,
                Idusuario = model.Idusuario,
            };
        }
    }

    public static partial class MapperCli
    {
        public static Cliente ToDatabase(this ClienteDTO dto)
        {
            return new Cliente()
            {
                Idcliente = dto.Idcliente,
                TipoDocumento = dto.TipoDoc,
                NombreDocumento = dto.NameDoc,
                PrimerNombre = dto.PNombre,
                SegundoNombre = dto.SNombre,
                PrimerApellido = dto.PApellido,
                SegundoApellido = dto.SApellido,
                TelefonoResidencia = dto.TelResidencia,
                TelefonoCelular = dto.TelCelular,
                Direccion = dto.Direccion,
                CiudadResidencia = dto.Ciudad,
                Departamento = dto.Departamento,
                Pais = dto.Pais,
                Profesion = dto.Profesion,
                Email = dto.Email,
                Idusuario = dto.Idusuario,
            };
        }
    }
}
