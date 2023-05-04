using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<RespuestaService<List<Usuario>>> Listar();
        Task<RespuestaService<Usuario>> BuscarPorId(int id);
        Task<RespuestaService<Usuario>> ValidarUsuario(string email, string contra);
        Task<RespuestaService<Usuario>> BuscarporTipoUsuario(int id);
        Task<RespuestaService<Usuario>> Guardar(Usuario us);
        Task<RespuestaService<Usuario>> Actualizar(Usuario us);
        Task<RespuestaService<bool>> Eliminar(int id);
    }
}
