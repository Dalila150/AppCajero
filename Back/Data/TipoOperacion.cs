using System;
using System.Collections.Generic;

namespace Back.Data;

public partial class TipoOperacion
{
    public int IdTipo { get; set; }

    public string Descripcion { get; set; } = null!;

    public virtual ICollection<Operacion> Operacions { get; set; } = new List<Operacion>();
}
