namespace Back.Helpers.Clases
{
    public class EntradaValidacionPin
    {
        public string numeroTarjeta { get; set; }
        public string pin { get; set; }
    }

    public class EntradaValidacionNumero
    {
        public string numeroTarjeta { get; set; }
    }

    public class EntradaOperacion
    {
        public long IdTarjeta { get; set; } 

        public int IdTipo { get; set; }

        public DateTime Hora { get; set; }

        public decimal? Monto { get; set; }
    }

    public class IntentosRestantes
    {
        public bool Valido { get; set; }
        public int Restantes { get; set; }
    }

    public class RespuestaValidacionTarjeta
    {
        public bool Valido { get; set; }
        public string Mensaje { get; set; }
    }

    public partial class RespuestaOperacion
    {
        public int IdOperacion { get; set; }

        public int IdTarjeta { get; set; }

        public int IdTipo { get; set; }

        public DateTime Hora { get; set; }

        public decimal? MontoRetirado { get; set; }

        public decimal SaldoActual { get; set; }
    }
}
