using Microsoft.JSInterop.Infrastructure;
using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperProd
    {
        public static ProductoDTO ToDTO(this Producto model) //Convierte de ModelContext a DTO 
        {
            return new ProductoDTO()
            {
                Idproducto = model.Idproducto,
                Nombre = model.Nombre,
                Descripcion = model.Descripcion,
                Color = model.Color,
                Dimensiones = model.Dimensiones,
                Foto = model.Foto,
                Precio = model.Precio,
                IdDetalle = model.Idordencompra,
                Idinventario = model.Idinventario,
                IdCategoria = model.Idcategoriaproducto,
                

            };
        }
    }

    public static partial class MapperProd
    {
        public static Producto ToDatabase(this ProductoDTO dto) // Converte de DTO a ModelContext
        {
            return new Producto()
            {
                Idproducto = dto.Idproducto,
                Nombre = dto.Nombre,
                Descripcion = dto.Descripcion,
                Color = dto.Color,
                Dimensiones= dto.Dimensiones,
                Foto= dto.Foto,
                Precio = dto.Precio,
                Idordencompra = dto.IdDetalle,
                Idinventario= dto.Idinventario,
                Idcategoriaproducto = dto.IdCategoria,
                
            };
        }
    }
}
