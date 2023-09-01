using Back.Data;
using Back.Helpers.Clases;

namespace Back.Interfaces
{
    public interface ITarjeta
    {
        //Auth
        Task<IEnumerable<Tarjeta>> ObtenerLista();
        Task<RespuestaValidacionTarjeta> ValidarNumero(EntradaValidacionNumero numeroTarjeta);
        Task<decimal> ConsultarSaldo(long idTarjeta, decimal? montoARetirar);
        Task<int> ConsultarId(long idTarjeta);
        Task<IntentosRestantes> ValidarPin(string numeroTarjeta, string pin);

    }
}
 