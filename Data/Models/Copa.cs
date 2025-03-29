using System;
using System.Collections.Generic;

namespace BarriolympicsRadzen.Data.Models;

public partial class Copa
{
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public Guid TipoId { get; set; }

    public string Imagen { get; set; }

    public DateOnly FechaGanada { get; set; }

    public Guid BarrieroId { get; set; }

    public Guid? EventoId { get; set; }

    public int Aura { get; set; }

    public virtual Barriero Barriero { get; set; }

    public virtual Evento Evento { get; set; }

    public virtual TipoCopa Tipo { get; set; }
}
