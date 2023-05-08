using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface ICardexService
    {
        Task<RespuestaService<List<Cardex>>> Listar();
        Task<RespuestaService<Cardex>> BuscarPorId(int id);
        //Task<RespuestaService<Cardex>> Guardar(Cardex ct);
        Task<RespuestaService<Cardex>> Actualizar(Cardex ct);
        //Task<RespuestaService<bool>> Eliminar(int id);
    }
}
