using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IDescuentoService
    {
        Task<RespuestaService<List<Descuento>>> Listar();
        Task<RespuestaService<Descuento>> BuscarPorId(int id);
        Task<RespuestaService<Descuento>> Guardar(Descuento ct);
        Task<RespuestaService<Descuento>> Actualizar(Descuento ct);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
