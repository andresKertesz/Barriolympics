using System;
using System.Collections.Generic;

namespace BarriolympicsRadzen.Data.Models;

public partial class Juego
{
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public string Link { get; set; }

    public Guid Tipo { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual ICollection<ImagenesJuego> ImagenesJuegos { get; set; } = new List<ImagenesJuego>();

    public virtual TipoJuego TipoNavigation { get; set; }
}
