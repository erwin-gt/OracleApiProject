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
    public class DetallePedidoService :IDetallePedidoService
    {
        private ModelContext _context;

        public DetallePedidoService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<DetallePedido>> Actualizar(DetallePedido ct)
        {
            var resp = new RespuestaService<DetallePedido>();
            var prov = await _context.DetallePedidos.FirstOrDefaultAsync(x => x.IddetallePedido == ct.IddetallePedido);

            if (prov == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                prov.Cantidad = ct.Cantidad;
                prov.Preciounitario = ct.Preciounitario;
                prov.Descuento = ct.Descuento;
                prov.Subtotal = ct.Subtotal = ct.Preciounitario*ct.Cantidad;
            try
            {
                _context.DetallePedidos.Update(prov);
                await _context.SaveChangesAsync();

                resp.Objeto = prov;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }
    

        public async Task<RespuestaService<DetallePedido>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<DetallePedido>();
            var prov = await _context.DetallePedidos.FirstOrDefaultAsync(x => x.IddetallePedido == id);

            // valida la existencia del ID del detalle pedido
            if (prov == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = prov;
            return resp;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var resp = new RespuestaService<bool>();
            var prov = await _context.DetallePedidos.FirstOrDefaultAsync(x => x.IddetallePedido == id);

            if (prov == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.DetallePedidos.Remove(prov);
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

        public async Task<RespuestaService<DetallePedido>> Guardar(DetallePedido ct)
        {
            var resp = new RespuestaService<DetallePedido>();

            try
            {
                await _context.DetallePedidos.AddAsync(ct);
                await _context.SaveChangesAsync();
                ct.IddetallePedido = await _context.DetallePedidos.MaxAsync(prv => prv.IddetallePedido);
                ct.Subtotal = ct.Cantidad * ct.Preciounitario;

                resp.Objeto = ct;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<DetallePedido>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<DetallePedido>>();
            var lista = await _context.DetallePedidos.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }

}
