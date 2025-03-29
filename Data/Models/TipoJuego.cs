using System;
using System.Collections.Generic;

namespace BarriolympicsRadzen.Data.Models;

public partial class TipoJuego
{
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public string Icon { get; set; }

    public virtual ICollection<Juego> Juegos { get; set; } = new List<Juego>();
}
