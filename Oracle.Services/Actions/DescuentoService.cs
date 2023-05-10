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
    public class DescuentoService : IDescuentoService
    {
        private ModelContext _context;

        public DescuentoService(ModelContext contect)
        {
            _context = contect;
        }

        public async Task<RespuestaService<Descuento>> Actualizar(Descuento ct)
        {
            var resp = new RespuestaService<Descuento>();
            var cate = await _context.Descuentos.FirstOrDefaultAsync(x => x.Iddescuento == ct.Iddescuento);

            if (cate == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                cate.TipoDescuento = ct.TipoDescuento;
                cate.CondicionesUso = ct.CondicionesUso;
                cate.PorcentajeDescuento = ct.PorcentajeDescuento;
                cate.DescuentoCantidad = ct.DescuentoCantidad;
            try
            {
                _context.Descuentos.Update(cate);
                await _context.SaveChangesAsync();

                resp.Objeto = cate;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<Descuento>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<Descuento>();
            var cate = await _context.Descuentos.FirstOrDefaultAsync(x => x.Iddescuento == id);

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
            var cate = await _context.Descuentos.FirstOrDefaultAsync(x => x.Iddescuento == id);

            if (cate == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.Descuentos.Remove(cate);
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

        public async Task<RespuestaService<Descuento>> Guardar(Descuento ct)
        {
            var resp = new RespuestaService<Descuento>();

            try
            {
                await _context.Descuentos.AddAsync(ct);
                await _context.SaveChangesAsync();
                ct.Iddescuento = await _context.Descuentos.MaxAsync(cate => cate.Iddescuento);

                resp.Objeto = ct;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<Descuento>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<Descuento>>();
            var lista = await _context.Descuentos.ToListAsync();


            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
