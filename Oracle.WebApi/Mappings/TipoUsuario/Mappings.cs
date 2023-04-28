using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperTU
    {
        public static TipoUserDTO ToDTO(this TipoUsuario model) //Convierte de ModelContext a DTO 
        {
            return new TipoUserDTO()
            {
                IdTipo = model.Idtipousuario,
                Clase = model.NombreTipoUsuario,
                F_Creacion = model.FechaCreacion,

            };
        }
    }

    public static partial class MapperTU
    {
        public static TipoUsuario ToDatabase(this TipoUserDTO dto) // Converte de DTO a ModelContext
        {
            return new TipoUsuario()
            {
                Idtipousuario = dto.IdTipo,
                NombreTipoUsuario = dto.Clase,
                FechaCreacion = dto.F_Creacion,
            };
        }
    }
}