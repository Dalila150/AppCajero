using System;
using System.Collections.Generic;

namespace Back.Data;

public partial class Operacion
{
    public int IdOperacion { get; set; }

    public int IdTarjeta { get; set; }

    public int IdTipo { get; set; }

    public DateTime Hora { get; set; }

    public decimal? Monto { get; set; }

    public virtual Tarjeta? IdTarjetaNavigation { get; set; } = null!;

    public virtual TipoOperacion? IdTipoNavigation { get; set; } = null!;
}
