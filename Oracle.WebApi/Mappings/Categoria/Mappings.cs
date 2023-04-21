using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperCat
    {
        public static CategoriaDTO ToDTO(this CategoriaProducto model) //Convierte de ModelContext a DTO 
        {
            return new CategoriaDTO()
            {
                Idcategoriaproducto = model.Idcategoriaproducto,
                Nombre = model.Nombre,
                Tipomueble = model.Tipomueble,
                Descripcion = model.Descripcion,

            };
        }
    }

    public static partial class MapperCat
    {
        public static CategoriaProducto ToDatabase(this CategoriaDTO dto) // Converte de DTO a ModelContext
        {
            return new CategoriaProducto()
            {
                Idcategoriaproducto = dto.Idcategoriaproducto,
                Nombre = dto.Nombre,
                Tipomueble = dto.Tipomueble,
                Descripcion = dto.Descripcion,
            };
        }
    }
}
