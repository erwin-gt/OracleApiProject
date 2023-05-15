using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IEmpleadoService
    {
        Task<RespuestaService<List<Empleado>>> Listar();
        Task<RespuestaService<Empleado>> BuscarPorId(int id);
        Task<RespuestaService<Empleado>> Guardar(Empleado us);
        Task<RespuestaService<Empleado>> Actualizar(Empleado us);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
