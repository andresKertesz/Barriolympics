using BarriolympicsRadzen.Data;
using BarriolympicsRadzen.Data.Models;
using BarriolympicsRadzen.Helpers;
using Blazored.LocalStorage;
using Microsoft.EntityFrameworkCore.Query;


namespace BarriolympicsRadzen.Controllers
{
    public class AuthenticationController
    {
        private const string TOKEN_KEY = "UTOKEN";
        private readonly ILocalStorageService _localStorage;
        private readonly ApplicationDbContext _applicationDbContext;
        public enum LoginResult
        {
            UserNotFound,
            UserLoggedInTooManyTimes,
            Success
        }
        public AuthenticationController(ILocalStorageService localStorage,ApplicationDbContext applicationDbContext)
        {
            _localStorage = localStorage;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<LoginResult> Login(string user, string password)
        {
            var usuario = _applicationDbContext.Usuarios.Where(x => x.Username == user).FirstOrDefault();
            if(usuario == null)
            {
                return LoginResult.UserNotFound;
            }

            if(usuario.Password != HashUtil.HashPassword(password))
            {
                return LoginResult.UserNotFound;
            }

            var tooManyLogins = _applicationDbContext.TokenLogins.Where(x => x.UsuarioId == usuario.Id && x.ValidoDesde < DateTime.Now && x.ValidoHasta > DateTime.Now).Count() >= 5;
            if (tooManyLogins)
            {
                return LoginResult.UserLoggedInTooManyTimes;
            }
            TokenLogin token = new()
            {
                 Id = Guid.NewGuid(),
                 Token = Guid.NewGuid(),
                 ValidoDesde = DateTime.Now,
                 ValidoHasta = DateTime.Now.AddMonths(1),
                 Habilitado = true,
                 UsuarioId = usuario.Id
            };
            //aca el user esta fullcockman
            await _localStorage.SetItemAsStringAsync(TOKEN_KEY, token.Token.ToString());
            await _applicationDbContext.TokenLogins.AddAsync(token);
            await _applicationDbContext.SaveChangesAsync();

            return LoginResult.Success;
        }
        public async Task Logout()
        {
            if(GetLoggedInUser() == null)
            {
                return;
            }
            bool tokenExists = await _localStorage.ContainKeyAsync(TOKEN_KEY);

            //disable update key
            if (!tokenExists)
            {
                return;
            }

            var lsToken = await _localStorage.GetItemAsStringAsync(TOKEN_KEY);
            var token = _applicationDbContext.TokenLogins.Where(x=>x.Habilitado && x.Token.ToString() == lsToken).FirstOrDefault ();
            
            if (token != null)
            {
                token.Habilitado = false;
                _applicationDbContext.Update(token);
                await _applicationDbContext.SaveChangesAsync();
            }
            await _localStorage.RemoveItemAsync(TOKEN_KEY);

            
        }


        public async Task<Usuario?> GetLoggedInUser()
        {
            bool tokenExists = await _localStorage.ContainKeyAsync(TOKEN_KEY);
            if (!tokenExists)
            {
                return null;
            }

            string token = await _localStorage.GetItemAsStringAsync(TOKEN_KEY);
            var tokenFound = _applicationDbContext.TokenLogins.Where(x => x.Token.ToString().Equals(token)).FirstOrDefault();

            if (tokenFound == null && (tokenFound.ValidoDesde > DateTime.Now || tokenFound.ValidoHasta < DateTime.Now))
            {
                await _localStorage.RemoveItemAsync(TOKEN_KEY);
                return null;
            }
            return _applicationDbContext.Usuarios.Where(x=>x.Id == tokenFound.UsuarioId).FirstOrDefault();
        }


    }
}
