using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface ITipoUserService
    {
        Task<RespuestaService<List<TipoUsuario>>> Listar();
        Task<RespuestaService<TipoUsuario>> BuscarPorId(int id);
        Task<RespuestaService<TipoUsuario>> Guardar(TipoUsuario tpu);
        Task<RespuestaService<TipoUsuario>> Actualizar(TipoUsuario tpu);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
