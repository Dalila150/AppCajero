using Back.Data;
using Back.Helpers.Clases;

namespace Back.Interfaces
{
    public interface IOperacion
    {
        //Obtencion de registros?
        Task<IEnumerable<Operacion>> ObtenerLista();
        //Task<IEnumerable<Operacion>> ObtenerListaXTarjeta(string numeroTarjeta);
        Task<bool> InsertarOperacion(EntradaOperacion operacion);

    }
}
