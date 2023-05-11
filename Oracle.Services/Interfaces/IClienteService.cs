using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IClienteService
    {
        Task<RespuestaService<List<Cliente>>> Listar();
        Task<RespuestaService<Cliente>> BuscarPorId(int id);
        Task<RespuestaService<Cliente>> Guardar(Cliente ct);
        Task<RespuestaService<Cliente>> Actualizar(Cliente ct);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
