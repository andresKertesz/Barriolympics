using BarriolympicsRadzen.Data;
using Blazored.LocalStorage;

namespace BarriolympicsRadzen.Controllers
{
    public class AuthenticationController
    {
        private readonly ILocalStorageService _localStorage;

        public AuthenticationController(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

    }
}
