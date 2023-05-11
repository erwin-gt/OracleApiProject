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
    public class PedidoService : IPedidoService
    {
        private ModelContext _context;

        public PedidoService(ModelContext context) { 
        
        _context = context;
        }

        public async Task<RespuestaService<Pedido>> Actualizar(Pedido ct)
        {
            var resp = new RespuestaService<Pedido>();
            var prov = await _context.Pedidos.FirstOrDefaultAsync(x => x.Idpedido == ct.Idpedido);

            if (prov == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                prov.Estadoenvio = ct.Estadoenvio;
                prov.Fechaentrega = ct.Fechaentrega;
            try
            {
                _context.Pedidos.Update(prov);
                await _context.SaveChangesAsync();

                resp.Objeto = prov;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<Pedido>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<Pedido>();
            var prov = await _context.Pedidos.FirstOrDefaultAsync(x => x.Idpedido == id);

            // valida la existencia del ID del usuario
            if (prov == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = prov;
            return resp;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var resp = new RespuestaService<bool>();
            var prov = await _context.Pedidos.FirstOrDefaultAsync(x => x.Idpedido == id);

            if (prov == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.Pedidos.Remove(prov);
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

        public async Task<RespuestaService<Pedido>> Guardar(Pedido ct)
        {
            var resp = new RespuestaService<Pedido>();

            try
            {
                await _context.Pedidos.AddAsync(ct);
                await _context.SaveChangesAsync();
                ct.Idpedido = await _context.Pedidos.MaxAsync(prv => prv.Idpedido);

                resp.Objeto = ct;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<Pedido>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<Pedido>>();
            var lista = await _context.Pedidos.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }

}
