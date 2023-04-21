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
    public class TerritorioService : ITerritorioService
    {
        private ModelContext _context;

        public TerritorioService(ModelContext contect)
        {
            _context = contect;
        }

        public async Task<RespuestaService<Territorio>> Actualizar(Territorio tr)
        {
            var resp = new RespuestaService<Territorio>();
            var terr = await _context.Territorios.FirstOrDefaultAsync(x => x.Idterritorio == tr.Idterritorio);

            if (terr == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                terr.Nombre = tr.Nombre;
                terr.Descripcion = tr.Descripcion;
                if (terr.Idregion == null)
                    resp.AgregarBadRequest("No existe dato region ingresada");
                else
                    terr.Idregion = tr.Idregion;
            try
            {
                _context.Territorios.Update(terr);
                await _context.SaveChangesAsync();
                resp.Objeto = terr;
            }
            catch (DbUpdateException ex) 
            {
                resp.AgregarInternalServerError(ex.Message); 
            }
            return resp;

        }

        public async Task<RespuestaService<Territorio>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<Territorio>();
            var terr = await _context.Territorios.FirstOrDefaultAsync(x => x.Idterritorio == id);

            // valida la existencia del ID del usuario
            if (terr == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = terr;
            return resp;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var resp = new RespuestaService<bool>();
            var terr = await _context.Territorios.FirstOrDefaultAsync(x => x.Idterritorio == id);

            if (terr == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.Territorios.Remove(terr);
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

        public async Task<RespuestaService<Territorio>> Guardar(Territorio tr)
        {
            var resp = new RespuestaService<Territorio>();

            try
            {
                await _context.Territorios.AddAsync(tr);
                await _context.SaveChangesAsync();
                tr.Idterritorio = await _context.Territorios.MaxAsync(prv => prv.Idterritorio);

                resp.Objeto = tr;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<Territorio>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<Territorio>>();
            var resp2 = new RespuestaService<List<Region>>();
            var lista = await _context.Territorios.ToListAsync();
            var lista2 =  await _context.Regions.ToListAsync();

            if (lista != null && lista2 != null)
            {
                resp.Objeto = lista;
                resp2.Objeto = lista2;
            }
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
