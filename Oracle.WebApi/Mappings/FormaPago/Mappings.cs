using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperFPago
    {
        public static FormaPagoDTO ToDTO(this FormaPago model)
        {
            return new FormaPagoDTO
            {
                Idformapago = model.Idformapago,
                Tipopago = model.Tipopago,
            };
        }
    }

    public static partial class MapperFPago
    {
        public static FormaPago ToDatabase(this FormaPagoDTO dto)
        {
            return new FormaPago()
            {
                Idformapago = dto.Idformapago,
                Tipopago = dto.Tipopago,
            };
        }
    }
}
