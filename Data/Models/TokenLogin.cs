using System;
using System.Collections.Generic;

namespace BarriolympicsRadzen.Data.Models;

public partial class TokenLogin
{
    public Guid Id { get; set; }

    public Guid UsuarioId { get; set; }

    public Guid Token { get; set; }

    public DateTime ValidoDesde { get; set; }

    public DateTime ValidoHasta { get; set; }

    public bool Habilitado { get; set; }

    public virtual Usuario Usuario { get; set; }
}
