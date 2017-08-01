using System.Linq;
using System.Threading.Tasks;
using Game21.Data;
using Game21.Data.Models;
using Microsoft.AspNetCore.Http;

namespace Game21.Service
{
    public class PlayerService
    {
        protected PlayerRepository Repository { get; }
        protected SessionService SessionService { get; }
        
        public PlayerService(PlayerRepository playerRepository, SessionService sessionService)
        {
            Repository = playerRepository;
            SessionService = sessionService;
        }

        public virtual void Logout()
        {
            SessionService.Abandon();
        }

        public virtual Player Login(string name)
        {
            return LoginAsync(name).Result;
        }
        
        public virtual async Task<Player> LoginAsync(string name)
        {
            var player = await Repository.FindByNameAsync(name);

            if (player == null)
            {
                player = Repository.Create(name);
                Repository.Save(player);
            }

            SessionService.PlayerId = player.ID;
            SessionService.IsLogined = true;
            
            return player;
        }

        public virtual Player Current
        {
            get
            {
                var playerId = SessionService.PlayerId;
                if (SessionService.IsLogined && playerId != null)
                {
                    return Repository.FindById(playerId);
                }

                return null;
            }
        }
        
        public virtual bool IsAuthorized => Current != null;
    }
}