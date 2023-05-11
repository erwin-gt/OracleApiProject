using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.DTO;
using Oracle.Services.Interfaces;
using Oracle.WebApi.Mappings;

namespace Oracle.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaService _servicio;

        public FacturaController(IFacturaService servicio)
        {
            _servicio = servicio;
        }

        // Lista la informacion de las Facturas
        [HttpGet]
        public async Task<ActionResult<List<FacturaDTO>>> Listar()
        {

            //Utilizado por el servicio creado IFacturService

            var retorno = await _servicio.Listar();

            //validacion del servicio
            if (retorno.Objeto != null)
                // return retorno.Objeto; Sin aplicar el uso del servicio
                return retorno.Objeto.Select(MapperFac.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }

        // Lista la informacion de los Facturas segun la ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<FacturaDTO>> BuscarPorId(int id)
        {


            var retorno = await _servicio.BuscarPorId(id);

            //validacion del servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }


        // Ingresa de datos
        [HttpPost]
        public async Task<ActionResult<FacturaDTO>> Guardar(FacturaDTO rg)
        {


            var retorno = await _servicio.Guardar(rg.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }
    }
}
