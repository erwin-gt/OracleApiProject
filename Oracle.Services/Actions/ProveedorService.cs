using Microsoft.EntityFrameworkCore;
using Oracle.DataAccess.Models;
using Oracle.Services.Interfaces;

namespace Oracle.Services.Actions
{
    public class ProveedorService : IProveedorService
    {
        private ModelContext _context;

        public ProveedorService(ModelContext contect)
        {
            _context = contect;
        }

        public async Task<RespuestaService<Proveedor>> Actualizar(Proveedor pr)
        {
            var resp = new RespuestaService<Proveedor>();
            var prov = await _context.Proveedors.FirstOrDefaultAsync(x => x.Idproveedor == pr.Idproveedor);

            if (prov == null)
                resp.AgregarBadRequest("ID recibido no esta registrado");
            else
                prov.Nombreempresa = pr.Nombreempresa;
                prov.Telefono = pr.Telefono;
                prov.Contacto = pr.Contacto;
                prov.Email = pr.Email;
            try
            {
                _context.Proveedors.Update(prov);
                await _context.SaveChangesAsync();

                resp.Objeto = prov;
            }
            catch (DbUpdateException ex)
            {
                resp.AgregarInternalServerError(ex.Message);
            }

            return resp;
        }

        public async Task<RespuestaService<Proveedor>> BuscarPorId(decimal id)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaService<bool>> Eliminar(decimal id)
        {
            throw new NotImplementedException();
        }

        public  Task<RespuestaService<Proveedor>> Guardar(Proveedor pr)
        {
            throw new NotImplementedException();
        }

        public async Task<RespuestaService<List<Proveedor>>> Listar()
        {
            //implementa y despliega el resultado de la lista 
            var resp = new RespuestaService<List<Proveedor>>();
            var lista = await _context.Proveedors.ToListAsync();

            if (lista != null)
                resp.Objeto = lista;
            else
                resp.AgregarInternalServerError("Se encontro un Erro");

            return resp;
        }
    }
}
