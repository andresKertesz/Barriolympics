﻿using System;
using System.Collections.Generic;

namespace BarriolympicsRadzen.Data.Models;

public partial class TipoCompetencium
{
    public Guid Id { get; set; }

    public string Nombre { get; set; }

    public string Descripcion { get; set; }

    public int Jerarquia { get; set; }

    public string Icon { get; set; }

    public virtual ICollection<Competencium> Competencia { get; set; } = new List<Competencium>();
}
