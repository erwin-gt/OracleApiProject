using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IRegionService
    {
        Task<RespuestaService<List<Region>>> Listar();
        Task<RespuestaService<Region>> BuscarPorId(decimal id);
        Task<RespuestaService<Region>> Guardar(Region rg);
        Task<RespuestaService<Region>> Actualizar(Region rg);
        Task<RespuestaService<bool>> Eliminar(int id);
      
    }
}
