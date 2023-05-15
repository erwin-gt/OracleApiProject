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
    public class DetalleFacturaService : IDetalleFacturaService
    {
        private ModelContext _context;

        public DetalleFacturaService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<DetalleFactura>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<DetalleFactura>();
            var prov = await _context.DetalleFacturas.FirstOrDefaultAsync(x => x.Iddetallefactura == id);

            // valida la existencia del ID del detalle pedido
            if (prov == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = prov;
            return resp;
        }

        public async Task<RespuestaService<List<DetalleFactura>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<DetalleFactura>>();
            var lista = await _context.DetalleFacturas.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
