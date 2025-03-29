using System;
using System.Collections.Generic;

namespace BarriolympicsRadzen.Data.Models;

public partial class Barriero
{
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public string Apellido { get; set; }

    public string Alias { get; set; }

    public string FormatoNombre { get; set; }

    public string Descripcion { get; set; }

    public string Color { get; set; }

    public string Icon { get; set; }

    public string Imagen { get; set; }

    public DateOnly FechaNacimiento { get; set; }

    public DateOnly FechaIncorporacion { get; set; }

    public virtual ICollection<Copa> Copas { get; set; } = new List<Copa>();
}
