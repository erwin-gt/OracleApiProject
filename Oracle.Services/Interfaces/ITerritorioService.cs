using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface ITerritorioService
    {
        Task<RespuestaService<List<Territorio>>> Listar();
        Task<RespuestaService<Territorio>> BuscarPorId(int id);
        Task<RespuestaService<Territorio>> Guardar(Territorio tr);
        Task<RespuestaService<Territorio>> Actualizar(Territorio tr);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
