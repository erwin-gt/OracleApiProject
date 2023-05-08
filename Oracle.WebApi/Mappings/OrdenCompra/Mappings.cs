using Oracle.DataAccess.Models;
using Oracle.DTO;

namespace Oracle.WebApi.Mappings
{
    public static partial class MapperODC
    {
        public static OrdenCompraDTO ToDTO(this OrdenCompra model) //Convierte de ModelContext a DTO 
        {
            return new OrdenCompraDTO()
            {
                Idordencompra = model.Idordencompra,
                Fechacompra = model.Fechacompra,
                Cantidad = model.Cantidad,
                Ubicacion = model.Ubicacion,
                Idproducto = model.Idproducto,7j-nnnnnnnnnnnnnnlñhñk k gggggggggggggghmmmmmjkdmdddddddddddddkkkkkkkkkkkkkkkkkkkkkkkkkkkjrhff3yyyyyyr777777777
                Idproveedor = model.Idproveedor,

            };
        }
    }

    public static partial class MapperODC
    {
        public static OrdenCompra ToDatabase(this OrdenCompraDTO dto) // Converte de DTO a ModelContext
        {
            return new OrdenCompra()
            {
                Idordencompra = dto.Idordencompra,
                Fechacompra = dto.Fechacompra,
                Cantidad = dto.Cantidad,
                Ubicacion = dto.Ubicacion,
                Idproducto = dto.Idproducto,
                Idproveedor = dto.Idproveedor,

            };
        }
    }
}
