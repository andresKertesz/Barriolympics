using BarriolympicsRadzen.Data;
using BarriolympicsRadzen.Data.Models;

namespace BarriolympicsRadzen.Controllers
{
    public class DatabaseController
    {

        private readonly ApplicationDbContext _dbContext;

        public DatabaseController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Barriero> GetBarrieros() 
        {
            return _dbContext.Barrieros.ToList();
        }
        public Barriero? GetBarriero(string DisplayName)
        {

            return _dbContext.Barrieros.Where(x => x.Alias == DisplayName).FirstOrDefault();
        }
        public List<TipoCompetencium> GetTipoEventos() 
        {
            return _dbContext.TipoCompetencia.OrderBy(x=> x.Jerarquia).ToList();
        }
        
        public List<TipoJuego> GetTipoJuegos() 
        {
            return _dbContext.TipoJuegos.ToList();
        }

    }
}
