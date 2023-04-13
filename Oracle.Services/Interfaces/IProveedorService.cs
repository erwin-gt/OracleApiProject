using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IProveedorService
    {
        Task<RespuestaService<List<Proveedor>>> Listar();
        Task<RespuestaService<Proveedor>> BuscarPorId(decimal id);
        Task<RespuestaService<Proveedor>> Guardar(Proveedor pr);
        Task<RespuestaService<Proveedor>> Actualizar(Proveedor pr);
        Task<RespuestaService<bool>> Eliminar(decimal id);
    }
}
