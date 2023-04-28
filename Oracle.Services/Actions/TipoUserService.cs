using Microsoft.EntityFrameworkCore;
using Oracle.DataAccess.Models;
using Oracle.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Actions
{
    public class TipoUserService : ITipoUserService
    {
        private ModelContext _context;

        public TipoUserService(ModelContext contect)
        {
            _context = contect;
        }

        public async Task<RespuestaService<TipoUsuario>> Actualizar(TipoUsuario tpu)
        {
            var resp = new RespuestaService<TipoUsuario>();
            var tus = await _context.TipoUsuarios.FirstOrDefaultAsync(x => x.Idtipousuario == tpu.Idtipousuario);

            if (tus == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                tus.NombreTipoUsuario = tpu.NombreTipoUsuario;
            try
            {
                _context.TipoUsuarios.Update(tus);
                await _context.SaveChangesAsync();

                resp.Objeto = tus;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;

        }

        public async Task<RespuestaService<TipoUsuario>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<TipoUsuario>();
            var tus = await _context.TipoUsuarios.FirstOrDefaultAsync(x => x.Idtipousuario == id);

            // valida la existencia del ID del usuario
            if (tus == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = tus;
            return resp;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var resp = new RespuestaService<bool>();
            var tus = await _context.TipoUsuarios.FirstOrDefaultAsync(x => x.Idtipousuario == id);

            if (tus == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.TipoUsuarios.Remove(tus);
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

        public async Task<RespuestaService<TipoUsuario>> Guardar(TipoUsuario tpu)
        {
            var resp = new RespuestaService<TipoUsuario>();

            try
            {
                await _context.TipoUsuarios.AddAsync(tpu);
                await _context.SaveChangesAsync();
                tpu.Idtipousuario = await _context.TipoUsuarios.MaxAsync(tu => tu.Idtipousuario);
                //tpu.FechaCreacion = dateOnly;

                resp.Objeto = tpu;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<TipoUsuario>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<TipoUsuario>>();
            var lista = await _context.TipoUsuarios.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
