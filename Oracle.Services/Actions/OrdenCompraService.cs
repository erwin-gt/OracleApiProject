using Microsoft.EntityFrameworkCore;
using Oracle.DataAccess.Models;
using Oracle.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Actions
{
    public class OrdenCompraService : IOrdenCompraService
    {
        private ModelContext _context;

        public OrdenCompraService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<OrdenCompra>> Actualizar(OrdenCompra ct)
        {
            var resp = new RespuestaService<OrdenCompra>();
            var cate = await _context.OrdenCompras.FirstOrDefaultAsync(x => x.Idordencompra == ct.Idordencompra);

            if (cate == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                cate.Fechacompra = ct.Fechacompra;
                cate.Cantidad = ct.Cantidad;
                cate.Ubicacion = ct.Ubicacion;
                cate.Idproducto = ct.Idproducto;
                cate.Idproveedor = ct.Idproveedor;
            try
            {
                _context.OrdenCompras.Update(cate);
                await _context.SaveChangesAsync();

                resp.Objeto = cate;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<OrdenCompra>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<OrdenCompra>();
            var cate = await _context.OrdenCompras.FirstOrDefaultAsync(x => x.Idordencompra == id);

            // valida la existencia del ID del de la orden de compra
            if (cate == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = cate;
            return resp;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var resp = new RespuestaService<bool>();
            var cate = await _context.OrdenCompras.FirstOrDefaultAsync(x => x.Idordencompra == id);

            if (cate == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.OrdenCompras.Remove(cate);
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

        public async Task<RespuestaService<OrdenCompra>> Guardar(OrdenCompra ct)
        {
            var resp = new RespuestaService<OrdenCompra>();

            try
            {
                await _context.OrdenCompras.AddAsync(ct);
                await _context.SaveChangesAsync();
                ct.Idordencompra = await _context.OrdenCompras.MaxAsync(cate => cate.Idordencompra);

                resp.Objeto = ct;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<OrdenCompra>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<OrdenCompra>>();
            var lista = await _context.OrdenCompras.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }

    }
}
