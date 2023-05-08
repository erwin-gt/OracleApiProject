using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperCar
    {
        public static CardexDTO ToDTO(this Cardex model)
        {
            return new CardexDTO
            {
                Idinventario = model.Idinventario,
                Descripcion = model.Descripcion,
                Cantidad = model.Cantidad,
                Preciounitario = model.Preciounitario,
                Valortotal = model.Valortotal,
                Registro = model.Fecharegistro,
                Actualizacion = model.Fechaultimaactualizacion,
                Nserie = model.Numeroserie,
                Almacen = model.Almacen,
                Observaciones = model.Observaciones,                
            };
        }
    }

    public static partial class MapperCar
    {
        public static Cardex ToDatabase(this CardexDTO dto)
        {
            return new Cardex()
            {
                Idinventario = dto.Idinventario,
                Descripcion = dto.Descripcion,
                Cantidad = dto.Cantidad,
                Preciounitario = dto.Preciounitario,
                Valortotal = dto.Valortotal,
                Fecharegistro = dto.Registro,
                Fechaultimaactualizacion = dto.Actualizacion,
                Numeroserie = dto.Nserie,
                Almacen = dto.Almacen,
                Observaciones = dto.Observaciones,                
            };
        }
    }
}
