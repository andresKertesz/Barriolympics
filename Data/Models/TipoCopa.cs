using System;
using System.Collections.Generic;

namespace BarriolympicsRadzen.Data.Models;

public partial class TipoCopa
{
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public string Imagen { get; set; }

    public int Prestigio { get; set; }

    public virtual ICollection<Copa> Copas { get; set; } = new List<Copa>();
}
