using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.DTO;
using Oracle.Services.Interfaces;
using Oracle.WebApi.Mappings;

namespace Oracle.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _servicio;

        public ProveedorController(IProveedorService servicio)
        {

            _servicio = servicio;
        }



        // Lista la informacion de los usuarios
        [HttpGet]
        public async Task<ActionResult<List<ProveedorDTO>>> Listar()
        {
          
            //Utilizado por el servicio creado IUsuarioService

            var retorno = await _servicio.Listar();

            //validacion del servicio
            if (retorno.Objeto != null)
                // return retorno.Objeto; Sin aplicar el uso del servicio
                return retorno.Objeto.Select(MapperProv.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);


        }


        // Lista la informacion de los usuarios segun la ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<ProveedorDTO>> BuscarPorId(decimal id)
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
        public async Task<ActionResult<ProveedorDTO>> Guardar(ProveedorDTO pr)
        {
           

            var retorno = await _servicio.Guardar(pr.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }


        // Actualiza datos
        [HttpPut]
        public async Task<ActionResult<ProveedorDTO>> Actualizar(ProveedorDTO pr)
        {
         

            var retorno = await _servicio.Actualizar(pr.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }


        // Elimina segun el ID ingresado
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Eliminar(decimal id)
        {

            var retorno = await _servicio.Eliminar(id);

            if (retorno.Exito)
                return true;
            else
                return StatusCode(retorno.Status, retorno.Error);
        }
    }
}
