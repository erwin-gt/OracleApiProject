using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.DTO;
using Oracle.Services.Interfaces;
using Oracle.WebApi.Mappings;

namespace Oracle.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleFacturaController : ControllerBase
    {
        private readonly IDetalleFacturaService _servicio;

        public DetalleFacturaController(IDetalleFacturaService servicio)
        {
            _servicio = servicio;
        }

        // Lista la informacion de los DetalleFactura
        [HttpGet]
        public async Task<ActionResult<List<DetalleFacturaDTO>>> Listar()
        {

            //Utilizado por el servicio creado IDetalleFacturaService

            var retorno = await _servicio.Listar();

            //validacion del servicio
            if (retorno.Objeto != null)
                // return retorno.Objeto; Sin aplicar el uso del servicio
                return retorno.Objeto.Select(MapperDfa.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        // Lista la informacion de los Detalles factura segun la ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleFacturaDTO>> BuscarPorId(int id)
        {


            var retorno = await _servicio.BuscarPorId(id);

            //validacion del servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }
    }
}
