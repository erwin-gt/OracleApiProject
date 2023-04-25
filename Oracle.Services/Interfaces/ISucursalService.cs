using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface ISucursalService
    {
        Task<RespuestaService<List<Sucursal>>> Listar();
        Task<RespuestaService<Sucursal>> BuscarPorId(int id);
        Task<RespuestaService<Sucursal>> Guardar(Sucursal su);
        Task<RespuestaService<Sucursal>> Actualizar(Sucursal su);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
