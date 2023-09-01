using System;
using System.Collections.Generic;

namespace Back.Data;

public partial class Tarjeta
{
    public int IdTarjeta { get; set; }

    public string Numero { get; set; } = null!;

    public string Pin { get; set; } = null!;

    public bool Activa { get; set; }

    public decimal Saldo { get; set; }

    public int IntentosRestantes { get; set; }

    public virtual ICollection<Operacion> Operacions { get; set; } = new List<Operacion>();
}
