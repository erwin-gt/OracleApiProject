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
    public class PuestoService : IPuestoService
    {
        private ModelContext _context;

        public PuestoService(ModelContext contect)
        {
            _context = contect;
        }

        public async Task<RespuestaService<Puesto>> Actualizar(Puesto ct)
        {
            var resp = new RespuestaService<Puesto>();
            var cate = await _context.Puestos.FirstOrDefaultAsync(x => x.Idpuesto == ct.Idpuesto);

            if (cate == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                cate.Nombrepuesto = ct.Nombrepuesto;
                cate.Departamento = ct.Departamento;
                cate.Niveljuridico = ct.Niveljuridico;
                cate.Salario = ct.Salario;
            try
            {
                _context.Puestos.Update(cate);
                await _context.SaveChangesAsync();

                resp.Objeto = cate;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<Puesto>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<Puesto>();
            var cate = await _context.Puestos.FirstOrDefaultAsync(x => x.Idpuesto == id);

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
            var cate = await _context.Puestos.FirstOrDefaultAsync(x => x.Idpuesto == id);

            if (cate == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.Puestos.Remove(cate);
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

        public async Task<RespuestaService<Puesto>> Guardar(Puesto ct)
        {
            var resp = new RespuestaService<Puesto>();

            try
            {
                await _context.Puestos.AddAsync(ct);
                await _context.SaveChangesAsync();
                ct.Idpuesto = await _context.Puestos.MaxAsync(cate => cate.Idpuesto);

                resp.Objeto = ct;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<Puesto>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<Puesto>>();
            var lista = await _context.Puestos.ToListAsync();


            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
