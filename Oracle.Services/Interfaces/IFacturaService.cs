using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IFacturaService
    {
        Task<RespuestaService<List<Factura>>> Listar();
        Task<RespuestaService<Factura>> BuscarPorId(int id);
        Task<RespuestaService<Factura>> Guardar(Factura fact);

    }
}
