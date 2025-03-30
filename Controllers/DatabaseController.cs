using BarriolympicsRadzen.Data;
using BarriolympicsRadzen.Data.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

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

        public List<Copa> GetBarriosGanadas(Guid guid)
        {
            return _dbContext.Copas.Where(x => x.BarrieroId == guid).
                Where(x=>x.Evento.Competencia.TipoNavigation.Nombre == "Barriolympics").ToList();
        }

        public List<Copa> GetCopasFromUser(Guid userId)
        {
            return _dbContext.Copas.Where(x => x.BarrieroId.Equals(userId)).ToList();
        }

        public TipoCopa GetTipoCopa(Guid copaId)
        {
            return _dbContext.TipoCopas.Where(x => x.Id.Equals(copaId)).FirstOrDefault();
        }
    }   
}   
