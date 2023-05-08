using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.DTO;
using Oracle.Services.Interfaces;
using Oracle.WebApi.Mappings;

namespace Oracle.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProductoService _servicio;
        
        public ProductoController(IProductoService servicio)
        {
            _servicio = servicio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductoDTO>>> Listar()
        {

            //Utilizado por el servicio creado Iproducto

            var retorno = await _servicio.Listar();

            //validacion del servicio
            if (retorno.Objeto != null)
                // return retorno.Objeto; Sin aplicar el uso del servicio
                return retorno.Objeto.Select(MapperProd.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

        // Lista la informacion de los Productos segun la ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDTO>> BuscarPorId(int id)
        {


            var retorno = await _servicio.BuscarPorId(id);

            //validacion del servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }

        [HttpGet("{id}/Inventario")]
        public async Task<ActionResult<ProductoDTO>> BuscarporInventario(int id)
        {


            var retorno = await _servicio.BuscarporInventario(id);

            //validacion del servicio
            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }

        [HttpPost]
        public async Task<ActionResult<ProductoDTO>> Guardar(ProductoDTO ct)
        {


            var retorno = await _servicio.Guardar(ct.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }

        [HttpPut]
        public async Task<ActionResult<ProductoDTO>> Actualizar(ProductoDTO ct)
        {


            var retorno = await _servicio.Actualizar(ct.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);
        }

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
