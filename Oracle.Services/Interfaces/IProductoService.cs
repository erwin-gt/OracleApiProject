using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IProductoService
    {
        Task<RespuestaService<List<Producto>>> Listar();
        Task<RespuestaService<Producto>> BuscarPorId(int id);
        Task<RespuestaService<Producto>> BuscarporInventario(int id);
        Task<RespuestaService<Producto>> Guardar(Producto us);
        Task<RespuestaService<Producto>> Actualizar(Producto us);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
