using System;

namespace Game21.Data
{
    public class PlayerRepository
    {
        public PlayersContext PlayersContext { get; }
        
        public PlayerRepository(PlayersContext playersContext)
        {
            PlayersContext = playersContext;
        }

        public virtual void FindByName(string name)
        {
            
        }
        
    }
}