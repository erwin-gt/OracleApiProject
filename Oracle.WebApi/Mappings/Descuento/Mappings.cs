using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    
        public static partial class MapperDes
        {
            public static DescuentoDTO ToDTO(this Descuento model)
            {
                return new DescuentoDTO
                {
                    Iddescuento = model.Iddescuento,
                    TipoDescuento = model.TipoDescuento,
                    CondicionesUso = model.CondicionesUso,
                    PorcentajeDescuento = model.PorcentajeDescuento,
                    DescuentoCantidad = model.DescuentoCantidad,
                };
            }
        }

        public static partial class MapperDes
        {
            public static Descuento ToDatabase(this DescuentoDTO dto)
            {
                return new Descuento()
                {
                    Iddescuento = dto.Iddescuento,
                    TipoDescuento = dto.TipoDescuento,
                    CondicionesUso = dto.CondicionesUso,
                    PorcentajeDescuento = dto.PorcentajeDescuento,
                    DescuentoCantidad = dto.DescuentoCantidad,
                    
                };
            }
        }
}
