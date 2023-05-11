using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperPed
    {
        public static PedidoDTO ToDTO(this Pedido model)
        {
            return new PedidoDTO
            {
                Idpedido = model.Idpedido,
                Fechapedido = model.Fechapedido,
                Fechaentrega = model.Fechaentrega,
                Estadoenvio = model.Estadoenvio,
                Idfactura = model.Idfactura,
            };
        }
    }

    public static partial class MapperPed
    {
        public static Pedido ToDatabase(this PedidoDTO dto)
        {
            return new Pedido()
            {
                Idpedido = dto.Idpedido,
                Fechapedido = dto.Fechapedido,
                Fechaentrega = dto.Fechaentrega,
                Estadoenvio = dto.Estadoenvio,
                Idfactura = dto.Idfactura,
            };
        }
    }
}
