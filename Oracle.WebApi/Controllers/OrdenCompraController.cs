using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.DataAccess.Models;
using Oracle.DTO;
using Oracle.Services.Interfaces;
using Oracle.WebApi.Mappings;

namespace Oracle.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenCompraController : ControllerBase
    {
        private readonly IOrdenCompraService _servicio;

        public OrdenCompraController(IOrdenCompraService servicio)
        {
            _servicio = servicio;
        }

        // Lista la informacion de las ordenes de compra
        [HttpGet]
        public async Task<ActionResult<List<OrdenCompraDTO>>> Listar()
        {

            //Utilizado por el servicio creado IUsuario

            var retorno = await _servicio.Listar();

            //validacion del servicio
            if (retorno.Objeto != null)
                // return retorno.Objeto; Sin aplicar el uso del servicio
                return retorno.Objeto.Select(MapperODC.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        // Ingresa de datos
        [HttpPost]
        public async Task<ActionResult<OrdenCompraDTO>> Guardar(OrdenCompraDTO ct)
        {


            var retorno = await _servicio.Guardar(ct.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenCompraDTO>> BuscarPorId(int id)
        {


            var retorno = await _servicio.BuscarPorId(id);

            //validacion del servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }

        [HttpPut]
        public async Task<ActionResult<OrdenCompraDTO>> Actualizar(OrdenCompraDTO ct)
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
