using Game21.Data.Models;
using Microsoft.AspNetCore.Http;

namespace Game21.Service
{
    public class SessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        private ISession Session => _httpContextAccessor.HttpContext.Session;
        
        public SessionService(IHttpContextAccessor accessor)
        {
            _httpContextAccessor = accessor;
        }

        public void Load()
        {
        }

        public string this[string key]
        {
            get => Session.GetString(key);
            set => Session.SetString(key, value);
        }

        public string PlayerId
        {
            get => Session.GetString("PlayerId");
            set => Session.SetString("PlayerId", value);
        }

        public bool IsLogined
        {
            get
            {
                bool result;
                var parsed = bool.TryParse(Session.GetString("isLogined"), out result);

                return parsed && result;
            }
            set => Session.SetString("isLogined", value.ToString());
        }
    }
}