using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.DTO;
using Oracle.Services.Interfaces;
using Oracle.WebApi.Mappings;
using System.Drawing.Drawing2D;

namespace Oracle.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _servicio;

        public RegionController(IRegionService servicio)
        {

            _servicio = servicio;
        }

        // Lista la informacion de los Regiones
        [HttpGet]
        public async Task<ActionResult<List<RegionDTO>>> Listar()
        {

            //Utilizado por el servicio creado IUsuarioService

            var retorno = await _servicio.Listar();

            //validacion del servicio
            if (retorno.Objeto != null)
                // return retorno.Objeto; Sin aplicar el uso del servicio
                return retorno.Objeto.Select(MapperReg.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);


        }


        // Lista la informacion de los REgiones segun la ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<RegionDTO>> BuscarPorId(decimal id)
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
        public async Task<ActionResult<RegionDTO>> Guardar(RegionDTO rg)
        {


            var retorno = await _servicio.Guardar(rg.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }


        // Actualiza datos
        [HttpPut]
        public async Task<ActionResult<RegionDTO>> Actualizar(RegionDTO rg)
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
