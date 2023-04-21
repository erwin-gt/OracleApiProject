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

        public Task<RespuestaService<CategoriaProducto>> Actualizar(CategoriaProducto ct)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaService<CategoriaProducto>> BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaService<bool>> Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaService<CategoriaProducto>> Guardar(CategoriaProducto ct)
        {
            throw new NotImplementedException();
        }

        public Task<RespuestaService<List<CategoriaProducto>>> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
