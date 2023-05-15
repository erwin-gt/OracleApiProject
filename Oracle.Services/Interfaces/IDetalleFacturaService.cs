using Oracle.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oracle.Services.Interfaces
{
    public interface IDetalleFacturaService
    {
        Task<RespuestaService<List<DetalleFactura>>> Listar();
        Task<RespuestaService<DetalleFactura>> BuscarPorId(int id);
    }
}
