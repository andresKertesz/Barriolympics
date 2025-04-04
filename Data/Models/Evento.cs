using System;
using System.Collections.Generic;

namespace BarriolympicsRadzen.Data.Models;

public partial class Evento
{
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public Guid? JuegoId { get; set; }

    public Guid? CompetenciaId { get; set; }

    public Guid? PadreId { get; set; }

    public DateOnly Fecha { get; set; }

    public virtual Competencium Competencia { get; set; }

    public virtual ICollection<Copa> Copas { get; set; } = new List<Copa>();

    public virtual Juego Juego { get; set; }
}
