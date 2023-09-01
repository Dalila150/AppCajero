using Back.Data;
using Back.Helpers.Clases;
using Back.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperacionController : ControllerBase
    {
        private readonly IOperacion _operaciones;
        private readonly ITarjeta _tarjetas;

        public OperacionController(IOperacion operaciones, ITarjeta tarjetas)
        {
            _operaciones = operaciones;
            _tarjetas = tarjetas;
        }

        //TODO deshabilitar endpoint
        [HttpGet("ObtenerOperaciones")]
        public async Task<IActionResult> ObtenerOperaciones()
        {
            var listaTarjetas = await _operaciones.ObtenerLista();
            
            return Ok(listaTarjetas);
               
        }

        /*
        [HttpGet("ObtenerOperacionesXTarjeta/{numeroTarjeta}")]
        public async Task<IActionResult> ObtenerOperacionesXTarjeta([FromRoute]string numeroTarjeta)
        {
            var id = await _tarjetas.
            var lista = await _operaciones.ObtenerListaXTarjeta(numeroTarjeta);
            
            return Ok(lista); 
        }*/

        [HttpPost("InsertarOperacion")]
        public async Task<IActionResult> InsertarOperacion([FromBody]EntradaOperacion operacion) //LLEGA LONG
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            //me pasan num tarjeta, yo busco el id
            var nuevoId = await _tarjetas.ConsultarId(operacion.IdTarjeta);

            decimal saldoActual = 0;
            
                saldoActual = await _tarjetas.ConsultarSaldo(nuevoId, operacion.Monto);
            operacion.IdTarjeta = nuevoId;
                if(saldoActual < operacion.Monto || operacion.Monto <= 0)
                    return BadRequest();
           
            try
            {
                var respuesta = await _operaciones.InsertarOperacion(operacion);
                if (respuesta)
                {
                    if(operacion.Monto == null)
                    {
                        return Ok(new RespuestaOperacion
                        {
                            IdTarjeta = nuevoId,
                            IdTipo = operacion.IdTipo,
                            Hora = operacion.Hora,
                            MontoRetirado = 0,
                            SaldoActual = saldoActual
                        });
                    }
                    else
                    {
                        return Ok(new RespuestaOperacion
                        {
                            IdTarjeta = nuevoId,
                            IdTipo = operacion.IdTipo,
                            Hora = operacion.Hora,
                            MontoRetirado = operacion.Monto,
                            SaldoActual = (decimal)(saldoActual - operacion.Monto)
                        });
                    }
                    
                }
                    
                else
                    return BadRequest();
                
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                throw;
            }
        }
    }
}
