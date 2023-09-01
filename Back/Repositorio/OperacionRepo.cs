using Back.Data;
using Back.Helpers.Clases;
using Back.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Back.Repositorio
{
    public class OperacionRepo : IOperacion
    {
        private readonly OriginSolutionsContext _conexion;
        public OperacionRepo(OriginSolutionsContext conexion)
        {
            _conexion = conexion;
        }

        
        public async Task<bool> InsertarOperacion(EntradaOperacion operacion)
        {
            Operacion opTemp = new Operacion
            {
                IdTarjeta = (int)operacion.IdTarjeta,
                IdTipo = operacion.IdTipo,
                Hora = operacion.Hora,
                Monto = operacion.Monto
            };

            _conexion.Operacions.Add(opTemp);

            try
            {
                var respuesta = await _conexion.SaveChangesAsync();
                if(respuesta == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Operacion>> ObtenerLista()
        {
            try
            {
                var lista = await _conexion.Operacions.ToListAsync();
                return lista;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                throw;
            }
        }

        /* TODO borrar metodo
        public async Task<IEnumerable<Operacion>> ObtenerListaXTarjeta(string numeroTarjeta)
        {
            try
            {
                var lista = await _conexion.Operacions.Where(x => x.);
                return lista;
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                throw;
            }
        }
        */
    }
}
