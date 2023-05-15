using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperDfa
    {
        public static DetalleFacturaDTO ToDTO(this DetalleFactura model)
        {
            return new DetalleFacturaDTO
            {
                Iddetallefactura = model.Iddetallefactura,
                Cantidad = model.Cantidad,
                Preciounitario = model.Preciounitario,
                Totaldetalle = model.Totaldetalle,
                Iddescuento = model.Iddescuento,
                Idfactura = model.Idfactura,
            };
        }
    }

    public static partial class MapperDfa
    {
        public static DetalleFactura ToDatabase(this DetalleFacturaDTO dto)
        {
            return new DetalleFactura()
            {
                Iddetallefactura = dto.Iddetallefactura,
                Cantidad = dto.Cantidad,
                Preciounitario = dto.Preciounitario,
                Totaldetalle = dto.Totaldetalle,
                Iddescuento = dto.Iddescuento,
                Idfactura = dto.Idfactura,
            };
        }
    }
}
