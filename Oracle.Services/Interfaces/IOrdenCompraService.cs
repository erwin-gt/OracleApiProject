using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IOrdenCompraService
    {
        Task<RespuestaService<List<OrdenCompra>>> Listar();
        Task<RespuestaService<OrdenCompra>> BuscarPorId(int id);
        Task<RespuestaService<OrdenCompra>> Guardar(OrdenCompra ct);
        Task<RespuestaService<OrdenCompra>> Actualizar(OrdenCompra ct);
        Task<RespuestaService<bool>> Eliminar(int id);
        
    }
}
