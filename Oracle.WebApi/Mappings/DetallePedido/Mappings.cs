using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperDpe
    {
        public static DetallePedidoDTO ToDTO(this DetallePedido model)
        {
            return new DetallePedidoDTO
            {
                IddetallePedido = model.IddetallePedido,
                Cantidad = model.Cantidad,
                Preciounitario = model.Preciounitario,
                Descuento = model.Descuento,
                Subtotal = model.Subtotal,
                Idpedido = model.Idpedido,
                Idproducto = model.Idproducto,
            };
        }
    }

    public static partial class MapperDpe
    {
        public static DetallePedido ToDatabase(this DetallePedidoDTO dto)
        {
            return new DetallePedido()
            {
                Idpedido = dto.Idpedido,
                Cantidad = dto.Cantidad,
                Preciounitario = dto.Preciounitario,
                Descuento = dto.Descuento,
                Subtotal = dto.Subtotal,
                Idproducto = dto.Idproducto,
                IddetallePedido = dto.IddetallePedido,
            };
        }
    }
}
