﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Oracle.DTO;
using Oracle.Services.Interfaces;
using Oracle.WebApi.Mappings;

namespace Oracle.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormaPagoController : ControllerBase
    {
        private readonly IFormaPagoService _servicio;

        public FormaPagoController(IFormaPagoService servicio)
        {

            _servicio = servicio;
        }

        // Lista la informacion de los tipos de pago
        [HttpGet]
        public async Task<ActionResult<List<FormaPagoDTO>>> Listar()
        {

            //Utilizado por el servicio creado IFormaPago

            var retorno = await _servicio.Listar();

            //validacion del servicio
            if (retorno.Objeto != null)
                // return retorno.Objeto; Sin aplicar el uso del servicio
                return retorno.Objeto.Select(MapperFPago.ToDTO).ToList();
            else
                return StatusCode(retorno.Status, retorno.Error);


        }
        // Lista la informacion de los Usaurios segun la ID ingresado
        [HttpGet("{id}")]
        public async Task<ActionResult<FormaPagoDTO>> BuscarPorId(int id)
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
        public async Task<ActionResult<FormaPagoDTO>> Guardar(FormaPagoDTO ct)
        {


            var retorno = await _servicio.Guardar(ct.ToDatabase());

            if (retorno.Objeto != null)
                return retorno.Objeto.ToDTO();
            else
                return StatusCode(retorno.Status, retorno.Error);

        }


        // Actualiza datos
        [HttpPut]
        public async Task<ActionResult<FormaPagoDTO>> Actualizar(FormaPagoDTO ct)
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
