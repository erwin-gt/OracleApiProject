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
    public class CategoriaService : ICategoriaService
    {
        private ModelContext _context;

        public CategoriaService(ModelContext contect)
        {
            _context = contect;
        }

        public async Task<RespuestaService<CategoriaProducto>> Actualizar(CategoriaProducto ct)
        {
            var resp = new RespuestaService<CategoriaProducto>();
            var cate = await _context.CategoriaProductos.FirstOrDefaultAsync(x => x.Idcategoriaproducto == ct.Idcategoriaproducto);

            if (cate == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                cate.Nombre = ct.Nombre;
                cate.Tipomueble = ct.Tipomueble;
                cate.Descripcion = ct.Descripcion;
            try
            {
                _context.CategoriaProductos.Update(cate);
                await _context.SaveChangesAsync();

                resp.Objeto = cate;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<CategoriaProducto>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<CategoriaProducto>();
            var cate = await _context.CategoriaProductos.FirstOrDefaultAsync(x => x.Idcategoriaproducto == id);

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
            var cate = await _context.CategoriaProductos.FirstOrDefaultAsync(x => x.Idcategoriaproducto == id);

            if (cate == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.CategoriaProductos.Remove(cate);
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

        public async Task<RespuestaService<CategoriaProducto>> Guardar(CategoriaProducto ct)
        {
            var resp = new RespuestaService<CategoriaProducto>();

            try
            {
                await _context.CategoriaProductos.AddAsync(ct);
                await _context.SaveChangesAsync();
                ct.Idcategoriaproducto = await _context.Proveedors.MaxAsync(cate => cate.Idproveedor);

                resp.Objeto = ct;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<CategoriaProducto>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<CategoriaProducto>>();
            var lista = await _context.CategoriaProductos.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
