using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IPuestoService
    {
        Task<RespuestaService<List<Puesto>>> Listar();
        Task<RespuestaService<Puesto>> BuscarPorId(int id);
        Task<RespuestaService<Puesto>> Guardar(Puesto us);
        Task<RespuestaService<Puesto>> Actualizar(Puesto us);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
