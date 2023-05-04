using Microsoft.EntityFrameworkCore;
using Oracle.DataAccess.Models;
using Oracle.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Actions
{
    public class UsuarioService : IUsuarioService
    {
        private ModelContext _context;

        public UsuarioService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Usuario>> Actualizar(Usuario us)
        {
            var resp = new RespuestaService<Usuario>();
            var usr = await _context.Usuarios.FirstOrDefaultAsync(x => x.Idusuario == us.Idusuario);

            if (usr == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                usr.Contraseña = us.Contraseña;
                usr.Email = us.Email;
                usr.Permisos = us.Permisos;
                usr.Rol = us.Rol;
                usr.Status = us.Status;
                usr.Idtipousuario = us.Idtipousuario;
                
            try
            {
                _context.Usuarios.Update(usr);
                await _context.SaveChangesAsync();

                resp.Objeto = usr;
            }
            catch (DbUpdateException ex)

            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<Usuario>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<Usuario>();
            var usr = await _context.Usuarios.FirstOrDefaultAsync(x => x.Idusuario == id);

            // valida la existencia del ID del sucursal
            if (usr == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = usr;
            return resp;
        }

        public async Task<RespuestaService<Usuario>> BuscarporTipoUsuario(int id)
        {
            var resp = new RespuestaService<Usuario>();
            var usr = await _context.Usuarios.FirstOrDefaultAsync(x => x.Idtipousuario == id);

            // valida la existencia del ID del sucursal
            if (usr == null)
                resp.AgregarBadRequest("No existen usuarios registrados con este tipo");
            else
                resp.Objeto = usr;
            return resp;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var resp = new RespuestaService<bool>();
            var usr = await _context.Usuarios.FirstOrDefaultAsync(x => x.Idusuario == id);

            if (usr == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.Usuarios.Remove(usr);
                    await _context.SaveChangesAsync();
                    resp.Exito = true;
                }
                catch (DbUpdateException ex)
                {
                    resp.AgregarInternalServerError(ex.Message);
                }
            }

            return resp;
        }

        public async Task<RespuestaService<Usuario>> Guardar(Usuario us)
        {
            var resp = new RespuestaService<Usuario>();

            try
            {
                await _context.Usuarios.AddAsync(us);
                await _context.SaveChangesAsync();
                us.Idusuario = await _context.Usuarios.MaxAsync(prv => prv.Idusuario);

                resp.Objeto = us;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<Usuario>>> Listar()
        {
            var resp = new RespuestaService<List<Usuario>>();
            var lista = await _context.Usuarios.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }


        //PARA VALIDAR LA EXISTENCIA DEL USUARIO
        public async Task<RespuestaService<Usuario>> ValidarUsuario(string email, string contra)
        {
            var resp = new RespuestaService<Usuario>();
            var usr = await _context.Usuarios.FirstOrDefaultAsync(x => x.Email == email & x.Contraseña == contra);

            // valida la existencia del ID del sucursal
            if (usr == null)
                resp.AgregarBadRequest("Datos ingresados no validos");
            else
                resp.Objeto = usr;
            return resp;
        }
    }
}
