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
    public class CardexService : ICardexService
    {
        private ModelContext _context;

        public CardexService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Cardex>> Actualizar(Cardex ct)
        {
            var resp = new RespuestaService<Cardex>();
            var cate = await _context.Cardices.FirstOrDefaultAsync(x => x.Idinventario == ct.Idinventario);

            if (cate == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                cate.Descripcion = ct.Descripcion;
                cate.Fechaultimaactualizacion = ct.Fechaultimaactualizacion;
                cate.Observaciones = ct.Observaciones;
            try
            {
                _context.Cardices.Update(cate);
                await _context.SaveChangesAsync();

                resp.Objeto = cate;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<Cardex>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<Cardex>();
            var cate = await _context.Cardices.FirstOrDefaultAsync(x => x.Idinventario == id);

            // valida la existencia del ID del usuario
            if (cate == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = cate;
            return resp;
        }

        public async Task<RespuestaService<List<Cardex>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<Cardex>>();
            var lista = await _context.Cardices.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }



   
}
