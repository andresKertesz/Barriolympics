using System.ComponentModel;

namespace BarriolympicsRadzen.Data.Models 
{ 
    public partial class Barriero 
    {
        public string DisplayName => FormatoNombre.Replace("[Nombre]", this.Nombre).Replace("[Apellido]", this.Apellido).Replace("[Alias]", this.Alias);
    }
}
