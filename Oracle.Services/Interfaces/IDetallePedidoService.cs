using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IDetallePedidoService
    {
        Task<RespuestaService<List<DetallePedido>>> Listar();
        Task<RespuestaService<DetallePedido>> BuscarPorId(int id);
        Task<RespuestaService<DetallePedido>> Guardar(DetallePedido ct);
        Task<RespuestaService<DetallePedido>> Actualizar(DetallePedido ct);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
