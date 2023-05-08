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
    public class ProductoService : IProductoService
    {
        private ModelContext _context;

        public ProductoService(ModelContext context)
        {
            _context = context;
        }

        public async Task<RespuestaService<Producto>> Actualizar(Producto prd)
        {
            var resp = new RespuestaService<Producto>();
            var cate = await _context.Productos.FirstOrDefaultAsync(x => x.Idproducto == prd.Idproducto);

            if (cate == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                cate.Nombre = prd.Nombre;                
                cate.Descripcion = prd.Descripcion;
                cate.Color = prd.Color;
                cate.Foto = prd.Foto;
                cate.Precio = prd.Precio;
                cate.Idcategoriaproducto = prd.Idcategoriaproducto;
                cate.Idordencompra = prd.Idordencompra;
                cate.Idinventario = prd.Idinventario;
            try
            {
                _context.Productos.Update(cate);
                await _context.SaveChangesAsync();

                resp.Objeto = cate;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<Producto>> BuscarPorId(int id)
        {
            var resp = new RespuestaService<Producto>();
            var cate = await _context.Productos.FirstOrDefaultAsync(x => x.Idproducto == id);

            // valida la existencia del ID del usuario
            if (cate == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
                resp.Objeto = cate;
            return resp;
        }

        public async Task<RespuestaService<Producto>> BuscarporInventario(int id)
        {
            var resp = new RespuestaService<Producto>();
            var cate = await _context.Productos.FirstOrDefaultAsync(x => x.Idinventario == id);

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
            var cate = await _context.Productos.FirstOrDefaultAsync(x => x.Idproducto == id);

            if (cate == null)
                resp.AgregarBadRequest("ID ingresado no esta registrado");
            else
            {
                try
                {
                    _context.Productos.Remove(cate);
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

        public async Task<RespuestaService<Producto>> Guardar(Producto prd)
        {
            var resp = new RespuestaService<Producto>();

            try
            {
                await _context.Productos.AddAsync(prd);
                await _context.SaveChangesAsync();
                prd.Idproducto = await _context.Productos.MaxAsync(cate => cate.Idproducto);

                resp.Objeto = prd;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarBadRequest(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<List<Producto>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<Producto>>();
            var lista = await _context.Productos.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Error");

            return resp;
        }
    }
}
