using Back.Helpers.Clases;
using Back.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarjetaController : ControllerBase
    {

        private readonly ITarjeta _tarjetas;

        public TarjetaController(ITarjeta tarjetas)
        {
            _tarjetas = tarjetas;
        }

        #region Extras
        

        #endregion

        [HttpPost("ValidarNumeroTarjeta")]
        public async Task<IActionResult> ValidarNumeroTarjeta([FromBody] EntradaValidacionNumero numeroTarjeta)
        {
            var respuesta = await _tarjetas.ValidarNumero(numeroTarjeta);
            if (respuesta.Valido)
                return Ok(respuesta);
            else
                return BadRequest(respuesta);
        }

        [HttpPost("ValidarPinTarjeta")]
        public async Task<IActionResult> ValidarPinTarjeta([FromBody] EntradaValidacionPin datos)
        {
            var respuesta = await _tarjetas.ValidarPin(datos.numeroTarjeta, datos.pin);
            if (respuesta.Valido)
                return Ok(respuesta);
            else
                return BadRequest(respuesta);
        }

        //TODO deshabilitar endpoint
        [HttpGet("ObtenerTarjetas")]
        public async Task<IActionResult> ObtenerTarjetas()
        {
            var lista = await _tarjetas.ObtenerLista();
            
            return Ok(lista);
            
        }

        /*
        [HttpPost("BloquearTarjeta")]
        public async Task<IActionResult> BloquearTarjeta([FromBody]int idTarjeta)
        {
            var respuesta = await _tarjetas.Bloquear(idTarjeta);
            return Ok(respuesta);
        }
        */
    }
}
