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
    public class ClienteService : IClienteService
    {
        private ModelContext _context;

        public ClienteService(ModelContext contect)
        {
            _context = contect;
        }

        public async Task<RespuestaService<Cliente>> Actualizar(Cliente ct)
        {
            var resp = new RespuestaService<Cliente>();
            var cate = await _context.Clientes.FirstOrDefaultAsync(x => x.Idcliente == ct.Idcliente);

            if (cate == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                cate.TipoDocumento = ct.TipoDocumento;
                cate.NombreDocumento = ct.NombreDocumento;
                cate.PrimerNombre = ct.PrimerNombre;
                cate.SegundoNombre = ct.SegundoNombre;
                cate.PrimerApellido = ct.PrimerApellido;
                cate.SegundoApellido = ct.SegundoApellido;
                cate.TelefonoResidencia = ct.TelefonoResidencia;
                cate.TelefonoCelular = ct.TelefonoCelular;
                cate.Direccion = ct.Direccion;
                cate.CiudadResidencia = ct.CiudadResidencia;
                cate.Departamento = ct.Departamento;
                cate.Profesion = ct.Profesion;
                cate.Email = ct.Email;
                cate.Idusuario = ct.Idusuario;
            try
            {
                _context.Clientes.Update(cate);
                await _context.SaveChangesAsync();

                resp.Objeto = cate;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<Cliente>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<Cliente>();
            var cate = await _context.Clientes.FirstOrDefaultAsync(x => x.Idcliente == id);

            // valida la existencia del ID del Cliente
            if (cate == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = cate;
            return resp;
        }

        public async Task<RespuestaService<bool>> Eliminar(int id)
        {
            var resp = new RespuestaService<bool>();
            var cate = await _context.Clientes.FirstOrDefaultAsync(x => x.Idcliente == id);

            if (cate == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.Clientes.Remove(cate);
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

        public async Task<RespuestaService<Cliente>> Guardar(Cliente ct)
        {
            var resp = new RespuestaService<Cliente>();

            try
            {
                await _context.Clientes.AddAsync(ct);
                await _context.SaveChangesAsync();
                ct.Idcliente = await _context.Clientes.MaxAsync(cate => cate.Idcliente);

                resp.Objeto = ct;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<Cliente>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<Cliente>>();
            var lista = await _context.Clientes.ToListAsync();


            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
