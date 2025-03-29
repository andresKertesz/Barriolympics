using System;
using System.Collections.Generic;

namespace BarriolympicsRadzen.Data.Models;

public partial class Competencium
{
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public DateOnly Fecha { get; set; }

    public string Imagen { get; set; }

    public Guid Tipo { get; set; }

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();

    public virtual TipoCompetencium TipoNavigation { get; set; }
}
