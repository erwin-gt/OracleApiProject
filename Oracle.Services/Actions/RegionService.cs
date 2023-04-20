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
    public class RegionService : IRegionService
    {
        private ModelContext _context;

        public RegionService(ModelContext contect)
        {
            _context = contect;
        }

        public async Task<RespuestaService<Region>> Actualizar(Region rg)
        {
            var resp = new RespuestaService<Region>();
            var regs = await _context.Regions.FirstOrDefaultAsync(x => x.Idregion == rg.Idregion);

            if (regs == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                regs.Nombre = rg.Nombre;
                regs.Ciudad = rg.Ciudad;
                regs.Provincia = rg.Provincia;
            try
            {
                _context.Regions.Update(regs);
                await _context.SaveChangesAsync();

                resp.Objeto = regs;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<Region>> BuscarPorId(decimal id)
        {
            var resp = new RespuestaService<Region>();
            var regs = await _context.Regions.FirstOrDefaultAsync(x => x.Idregion == id);

            // valida la existencia del ID de la region
            if (regs == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = regs;
            return resp;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var resp = new RespuestaService<bool>();
            var regs = await _context.Regions.FirstOrDefaultAsync(x => x.Idregion == id);

            if (regs == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.Regions.Remove(regs);
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

        public async Task<RespuestaService<Region>> Guardar(Region rg)
        {
            var resp = new RespuestaService<Region>();

            try
            {
                await _context.Regions.AddAsync(rg);
                await _context.SaveChangesAsync();
                rg.Idregion = await _context.Regions.MaxAsync(reg => reg.Idregion);

                resp.Objeto = rg;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<Region>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<Region>>();
            var lista = await _context.Regions.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
 }

