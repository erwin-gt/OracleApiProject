using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperTer
    {
        public static TerritorioDTO ToDTO(this Territorio model) //Convierte de ModelContext a DTO 
        {
            return new TerritorioDTO()
            {
                Idterritorio = model.Idterritorio,
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                Region = model.Idregion,

            };
        }
    }

    public static partial class MapperTer
    {
        public static Territorio ToDatabase(this TerritorioDTO dto) // Converte de DTO a ModelContext
        {
            return new Territorio()
            {
                Idterritorio = dto.Idterritorio,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Idregion = dto.Region,
            };
        }
    }
}
