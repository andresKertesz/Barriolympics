using System;
using System.Collections.Generic;

namespace BarriolympicsRadzen.Data.Models;

public partial class GetWinsPerCup
{
    public Guid IdBarriero { get; set; }

    public Guid IdJuego { get; set; }

    public int? CantidadCopas { get; set; }
}
