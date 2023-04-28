using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.DTO;
using Oracle.Services.Interfaces;
using Oracle.WebApi.Mappings;

namespace Oracle.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoUserController : ControllerBase
    {
        private readonly ITipoUserService _servicio;

        public TipoUserController(ITipoUserService servicio)
        {

            _servicio = servicio;
        }


        // Lista la informacion de los Tipo Usuario
        [HttpGet]
        public async Task<ActionResult<List<TipoUserDTO>>> Listar()
        {

            //Utilizado por el servicio creado IUsuarioService

            var retorno = await _servicio.Listar();

            //validacion del servicio
            if (retorno.Objeto != null)
                // return retorno.Objeto; Sin aplicar el uso del servicio
                return retorno.Objeto.Select(MapperTU.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);


        }


        // Lista la informacion de los Típo Usuario segun la ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoUserDTO>> BuscarPorId(int id)
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
        public async Task<ActionResult<TipoUserDTO>> Guardar(TipoUserDTO pr)
        {


            var retorno = await _servicio.Guardar(pr.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }


        // Actualiza datos
        [HttpPut]
        public async Task<ActionResult<TipoUserDTO>> Actualizar(TipoUserDTO pr)
        {


            var retorno = await _servicio.Actualizar(pr.ToDatabase());

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
