using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperFac
    {
        public static FacturaDTO ToDTO(this Factura model)
        {
            return new FacturaDTO
            {
                Idfactura = model.Idfactura,
                Fechaemision = model.Fechaemision,
                Total = model.Total,
                Estadofactura = model.Estadofactura,
                Notas = model.Notas,
                Idcliente = model.Idcliente,
                Idempleado = model.Idempleado,
                Idformapago = model.Idformapago,
            };
        }
    }

    public static partial class MapperFac
    {
        public static Factura ToDatabase(this FacturaDTO dto)
        {
            return new Factura()
            {
                Idfactura = dto.Idfactura,
                Fechaemision = dto.Fechaemision,
                Total = dto.Total,
                Estadofactura = dto.Estadofactura,
                Notas = dto.Notas,
                Idcliente = dto.Idcliente,
                Idempleado = dto.Idempleado,
                Idformapago = dto.Idformapago,
            };
        }
    }
}
