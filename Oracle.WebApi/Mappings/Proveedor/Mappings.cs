using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperProv
    {
        public static ProveedorDTO ToDTO(this Proveedor model) //Convierte de ModelContext a DTO 
        {
            return new ProveedorDTO()
            {
                Idprov = model.Idproveedor,
                NEmpresa = model.Nombreempresa,
                Contact = model.Contacto,
                Tel = model.Telefono,
                Email = model.Email,
                
            };
        }
    }

    public static partial class MapperProv
    {
        public static Proveedor ToDatabase(this ProveedorDTO dto) // Converte de DTO a ModelContext
        {
            return new Proveedor()
            {
                Idproveedor = dto.Idprov,
                Nombreempresa = dto.NEmpresa,
                Contacto = dto.Contact,
                Telefono = dto.Tel,
                Email = dto.Email
            };
        }
    }
}
