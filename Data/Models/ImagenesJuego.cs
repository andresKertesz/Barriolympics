﻿using System;
using System.Collections.Generic;

namespace BarriolympicsRadzen.Data.Models;

public partial class ImagenesJuego
{
    public Guid Id { get; set; }

    public Guid JuegoId { get; set; }

    public string Descripcion { get; set; }

    public string Url { get; set; }

    public virtual Juego Juego { get; set; }
}
