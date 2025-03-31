using System;
using System.Collections.Generic;

namespace BarriolympicsRadzen.Data.Models;

public partial class Usuario
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string Password { get; set; }

    public string Icon { get; set; }

    public virtual ICollection<TokenLogin> TokenLogins { get; set; } = new List<TokenLogin>();
}
