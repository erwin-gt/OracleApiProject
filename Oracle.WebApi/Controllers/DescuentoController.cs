using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.DTO;
using Oracle.Services.Interfaces;
using Oracle.WebApi.Mappings;

namespace Oracle.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescuentoController : ControllerBase
    {
        private readonly IDescuentoService _servicio;

        public DescuentoController(IDescuentoService servicio)
        {

            _servicio = servicio;
        }

        // Lista la informacion de los descuentos
        [HttpGet]
        public async Task<ActionResult<List<DescuentoDTO>>> Listar()
        {

            //Utilizado por el servicio creado IDescuento

            var retorno = await _servicio.Listar();

            //validacion del servicio
            if (retorno.Objeto != null)
                // return retorno.Objeto; Sin aplicar el uso del servicio
                return retorno.Objeto.Select(MapperDes.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);


        }
        // Lista la informacion de los Descuentos segun la ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<DescuentoDTO>> BuscarPorId(int id)
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
        public async Task<ActionResult<DescuentoDTO>> Guardar(DescuentoDTO ct)
        {


            var retorno = await _servicio.Guardar(ct.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }


        // Actualiza datos
        [HttpPut]
        public async Task<ActionResult<DescuentoDTO>> Actualizar(DescuentoDTO ct)
        {


            var retorno = await _servicio.Actualizar(ct.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }


        // Elimina segun el ID ingresado
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Eliminar(int id)
        {

            var retorno = await _servicio.Eliminar(id);

            if (retorno.Exito)
                return true;
            else
                return StatusCode(retorno.Status, retorno.Error);
        }
    }
}
