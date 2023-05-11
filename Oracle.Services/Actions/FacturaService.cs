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
    public class FacturaService : IFacturaService
    {
        private ModelContext _context;

        public FacturaService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Factura>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<Factura>();
            var cate = await _context.Facturas.FirstOrDefaultAsync(x => x.Idfactura == id);

            // valida la existencia del ID de la factura
            if (cate == null)
                resp.AgregarBadRequest("ID de Factura ingresado no esta registrado");
            else
                resp.Objeto = cate;
            return resp;
        }

        public async Task<RespuestaService<Factura>> Guardar(Factura fact)
        {
            var resp = new RespuestaService<Factura>();

            try
            {
                await _context.Facturas.AddAsync(fact);
                await _context.SaveChangesAsync();
                fact.Idfactura = await _context.Facturas.MaxAsync(cate => cate.Idfactura);
                fact.Estadofactura = "Pendiente Pago";

                resp.Objeto = fact;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<Factura>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<Factura>>();
            var lista = await _context.Facturas.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
