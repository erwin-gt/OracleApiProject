using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IFormaPagoService
    {
        Task<RespuestaService<List<FormaPago>>> Listar();
        Task<RespuestaService<FormaPago>> BuscarPorId(int id);
        Task<RespuestaService<FormaPago>> Guardar(FormaPago ct);
        Task<RespuestaService<FormaPago>> Actualizar(FormaPago ct);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
