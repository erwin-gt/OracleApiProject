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
    public class FormaPagoService : IFormaPagoService
    {
        private ModelContext _context;

        public FormaPagoService(ModelContext contect)
        {
            _context = contect;
        }

        public async Task<RespuestaService<FormaPago>> Actualizar(FormaPago ct)
        {
            var resp = new RespuestaService<FormaPago>();
            var cate = await _context.FormaPagos.FirstOrDefaultAsync(x => x.Idformapago == ct.Idformapago);

            if (cate == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                cate.Tipopago = ct.Tipopago;
            try
            {
                _context.FormaPagos.Update(cate);
                await _context.SaveChangesAsync();

                resp.Objeto = cate;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<FormaPago>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<FormaPago>();
            var cate = await _context.FormaPagos.FirstOrDefaultAsync(x => x.Idformapago == id);

            // valida la existencia del ID del usuario
            if (cate == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = cate;
            return resp;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var resp = new RespuestaService<bool>();
            var cate = await _context.FormaPagos.FirstOrDefaultAsync(x => x.Idformapago == id);

            if (cate == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.FormaPagos.Remove(cate);
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

        public async Task<RespuestaService<FormaPago>> Guardar(FormaPago ct)
        {
            var resp = new RespuestaService<FormaPago>();

            try
            {
                await _context.FormaPagos.AddAsync(ct);
                await _context.SaveChangesAsync();
                ct.Idformapago = await _context.FormaPagos.MaxAsync(cate => cate.Idformapago);

                resp.Objeto = ct;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<FormaPago>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<FormaPago>>();
            var lista = await _context.FormaPagos.ToListAsync();


            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
