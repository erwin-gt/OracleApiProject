using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<RespuestaService<List<CategoriaProducto>>> Listar();
        Task<RespuestaService<CategoriaProducto>> BuscarPorId(int id);
        Task<RespuestaService<CategoriaProducto>> Guardar(CategoriaProducto ct);
        Task<RespuestaService<CategoriaProducto>> Actualizar(CategoriaProducto ct);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
