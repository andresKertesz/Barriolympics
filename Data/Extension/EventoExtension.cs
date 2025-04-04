
namespace BarriolympicsRadzen.Data.Models
{
    public partial class Evento
    {
        public bool IsCompetition => this.CompetenciaId != null && this.JuegoId == null;


    }
}
