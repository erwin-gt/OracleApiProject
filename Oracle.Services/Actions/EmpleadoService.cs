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
    public class EmpleadoService :IEmpleadoService
    {
        private ModelContext _context;

        public EmpleadoService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Empleado>> Actualizar(Empleado ct)
        {
            var resp = new RespuestaService<Empleado>();
            var emp = await _context.Empleados.FirstOrDefaultAsync(x => x.Idempleado == ct.Idempleado);

            if (emp == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                //Estos datos son los unicos modificables, por el hecho que los demas son datos importantes
                emp.Salario = ct.Salario;
                emp.Direccion = ct.Direccion;
                emp.Email = ct.Email;
                emp.Telefono = ct.Telefono;
                emp.Evaluaciondesempeno = ct.Evaluaciondesempeno;
                emp.Idpuesto = ct.Idpuesto;
                emp.Idsucursal = ct.Idsucursal;
            try
            {
                _context.Empleados.Update(emp);
                await _context.SaveChangesAsync();

                resp.Objeto = emp;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<Empleado>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<Empleado>();
            var prov = await _context.Empleados.FirstOrDefaultAsync(x => x.Idempleado == id);

            // valida la existencia del ID del Empleado
            if (prov == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = prov;
            return resp;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var resp = new RespuestaService<bool>();
            var emp = await _context.Empleados.FirstOrDefaultAsync(x => x.Idempleado == id);

            if (emp == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.Empleados.Remove(emp);
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

        public async Task<RespuestaService<Empleado>> Guardar(Empleado ct)
        {
            var resp = new RespuestaService<Empleado>();

            try
            {
                await _context.Empleados.AddAsync(ct);
                await _context.SaveChangesAsync();
                ct.Idempleado = await _context.Empleados.MaxAsync(prv => prv.Idempleado);
                

                resp.Objeto = ct;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<Empleado>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<Empleado>>();
            var lista = await _context.Empleados.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
    
}
