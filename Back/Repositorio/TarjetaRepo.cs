using Back.Data;
using Back.Helpers.Clases;
using Back.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back.Repositorio
{
    public class TarjetaRepo : ITarjeta
    {
        private readonly OriginSolutionsContext _conexion;
        public TarjetaRepo(OriginSolutionsContext conexion)
        {
            _conexion = conexion;
        }

        public async Task<decimal> ConsultarSaldo(long idTarjeta, decimal? saldoARetirar) //usa Id
        {
            var busqueda = await _conexion.Tarjeta.Where(x => x.IdTarjeta == idTarjeta && x.Activa == true).FirstOrDefaultAsync();
            if(busqueda == null)
            {
                return -1;
            }
            return busqueda.Saldo;
        }

        public async Task<int> ConsultarId(long numeroTarjeta)
        {
            var busqueda = await _conexion.Tarjeta.Where(x => x.Numero == numeroTarjeta.ToString() && x.Activa == true).FirstOrDefaultAsync();
            if (busqueda == null)
            {
                return -1;
            }
            return busqueda.IdTarjeta;
        }

        public async Task<IEnumerable<Tarjeta>> ObtenerLista()
        {
            try
            {
                var lista = await _conexion.Tarjeta.ToListAsync();
                return lista;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                throw;
            }
        }

        //TODO 
        //asegurar que desde el front en todo caso, no deje ingresar pin o volver a validar el bloqueo
        public async Task<RespuestaValidacionTarjeta> ValidarNumero(EntradaValidacionNumero numeroTarjeta)
        {
            var tarjeta = await _conexion.Tarjeta.Where(x => x.Numero == numeroTarjeta.numeroTarjeta).FirstOrDefaultAsync();
            RespuestaValidacionTarjeta respuesta = new RespuestaValidacionTarjeta();
            if (tarjeta != null && tarjeta.Activa == true)
            {
                respuesta.Valido = true;
                respuesta.Mensaje = "Tarjeta valida";
            }
            else
            {
                respuesta.Valido = false;
                respuesta.Mensaje = "La tarjeta no existe o esta bloqueada.";
            }
            return respuesta;
        }

        private async Task<int> BloquearTarjeta(int idTarjeta)
        {
            var busqueda = await _conexion.Tarjeta.Where(x => x.IdTarjeta == idTarjeta).FirstOrDefaultAsync();
            busqueda.Activa = false;

            _conexion.Tarjeta.Update(busqueda);

            try
            {
                var respuesta = await _conexion.SaveChangesAsync();
                return respuesta;
            }
            catch (Exception error)
            {
                //Console.WriteLine(error);
                throw;
            }
        }

        private async Task<int> RestarIntentoAsync(Tarjeta tarjeta)
        {
            
            tarjeta.IntentosRestantes --;
            _conexion.Tarjeta.Update(tarjeta);
            if (tarjeta.IntentosRestantes == 0)
               await BloquearTarjeta(tarjeta.IdTarjeta);
            
            try
            {
                await _conexion.SaveChangesAsync();
                return tarjeta.IntentosRestantes;
            }
            catch (Exception error)
            {
                throw;
            }
        }

        //TODO volver a validar tarjeta
        public async Task<IntentosRestantes> ValidarPin(string numeroTarjeta, string pin)
        {
            var tarjeta = await _conexion.Tarjeta.Where(x => x.Numero == numeroTarjeta).FirstOrDefaultAsync();
            IntentosRestantes respuesta = new IntentosRestantes();
            
            if (tarjeta.Pin.Trim() == pin)
            {
                respuesta.Valido = true;
                respuesta.Restantes = tarjeta.IntentosRestantes;
            }
            else
            {
                respuesta.Valido = false;
                respuesta.Restantes = await RestarIntentoAsync(tarjeta);
            }

            return respuesta;

        }
    }
}
