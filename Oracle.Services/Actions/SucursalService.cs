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
    public class SucursalService : ISucursalService
    {
        private ModelContext _context;

        public SucursalService(ModelContext contect)
        {
            _context = contect;
        }

        public async Task<RespuestaService<Sucursal>> Actualizar(Sucursal su)
        {
            var resp = new RespuestaService<Sucursal>();
            var sucu = await _context.Sucursals.FirstOrDefaultAsync(x => x.Idsucursal == su.Idsucursal);

            if (sucu == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                sucu.Nombre = su.Nombre;
                sucu.Direccion = su.Direccion;
                sucu.Numero = su.Numero;
                sucu.Email = su.Email;
                sucu.Idterritorio = su.Idterritorio;
            try
            {
                _context.Sucursals.Update(sucu);
                await _context.SaveChangesAsync();

                resp.Objeto = sucu;
            }
            catch (DbUpdateException ex)

            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<Sucursal>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<Sucursal>();
            var sucu = await _context.Sucursals.FirstOrDefaultAsync(x => x.Idsucursal == id);

            // valida la existencia del ID del sucursal
            if (sucu == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = sucu;
            return resp;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var resp = new RespuestaService<bool>();
            var sucu = await _context.Sucursals.FirstOrDefaultAsync(x => x.Idsucursal == id);

            if (sucu == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.Sucursals.Remove(sucu);
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

        public async Task<RespuestaService<Sucursal>> Guardar(Sucursal su)
        {
            var resp = new RespuestaService<Sucursal>();

            try
            {
                await _context.Sucursals.AddAsync(su);
                await _context.SaveChangesAsync();
                su.Idsucursal = await _context.Sucursals.MaxAsync(prv => prv.Idsucursal);

                resp.Objeto = su;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<Sucursal>>> Listar()
        {
            var resp = new RespuestaService<List<Sucursal>>();
            var lista = await _context.Sucursals.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
