using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IPedidoService
    {
        Task<RespuestaService<List<Pedido>>> Listar();
        Task<RespuestaService<Pedido>> BuscarPorId(int id);
        Task<RespuestaService<Pedido>> Guardar(Pedido ct);
        Task<RespuestaService<Pedido>> Actualizar(Pedido ct);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
