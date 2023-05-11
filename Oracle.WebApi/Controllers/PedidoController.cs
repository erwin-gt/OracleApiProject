using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.DTO;
using Oracle.Services.Interfaces;
using Oracle.WebApi.Mappings;

namespace Oracle.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IPedidoService _servicio;

        public PedidoController (IPedidoService servicio)
        {
            _servicio = servicio;
        }

        // Lista la informacion de los Pedidos
        [HttpGet]
        public async Task<ActionResult<List<PedidoDTO>>> Listar()
        {

            //Utilizado por el servicio creado IPedidosSevice

            var retorno = await _servicio.Listar();

            //validacion del servicio
            if (retorno.Objeto != null)
                // return retorno.Objeto; Sin aplicar el uso del servicio
                return retorno.Objeto.Select(MapperPed.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);


        }


        // Lista la informacion de los Pedidos segun la ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoDTO>> BuscarPorId(int id)
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
        public async Task<ActionResult<PedidoDTO>> Guardar(PedidoDTO rg)
        {


            var retorno = await _servicio.Guardar(rg.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }


        // Actualiza datos
        [HttpPut]
        public async Task<ActionResult<PedidoDTO>> Actualizar(PedidoDTO rg)
        {


            var retorno = await _servicio.Actualizar(rg.ToDatabase());

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
