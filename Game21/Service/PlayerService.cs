using System.Linq;
using Game21.Data;
using Game21.Data.Models;
using Microsoft.AspNetCore.Http;

namespace Game21.Service
{
    public class PlayerService
    {
        protected PlayerRepository Repository { get; }
        
        public PlayerService(PlayerRepository playerRepository)
        {
            Repository = playerRepository;
        }

        public virtual void Logout()
        {
            
        }
        
        public virtual Player Login(string name)
        {
             // TODO: implement
            return null;
        }
        
        public virtual Player Current { get; }
        
        public virtual bool IsAuthorized => Current != null;
    }
}