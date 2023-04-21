using Oracle.DataAccess.Models;
using Oracle.DTO;


namespace Oracle.WebApi.Mappings
{
    public static partial class MapperReg
    {
        public static RegionDTO ToDTO(this Region model) //Convierte de ModelContext a DTO 
        {
            return new RegionDTO()
            {
                Idregion = model.Idregion,
                NRegion = model.Nombre,
                Ciudad = model.Ciudad,
                Provincia = model.Provincia,
            };
        }
    }

    public static partial class MapperReg
    {
        public static Region ToDatabase(this RegionDTO dto) // Converte de DTO a ModelContext
        {
            return new Region()
            {
                Idregion = dto.Idregion,
                Nombre = dto.NRegion,
                Ciudad = dto.Ciudad,
                Provincia = dto.Provincia,
            };
        }
    }
}
