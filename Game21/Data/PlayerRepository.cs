using System;
using System.Linq;
using System.Threading.Tasks;
using Game21.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Game21.Data
{
    public class PlayerRepository
    {
        public PlayersContext PlayersContext { get; }
        
        public PlayerRepository(PlayersContext playersContext)
        {
            PlayersContext = playersContext;
        }

        private IIncludableQueryable<Player, Stats> PlayersIncluded =>
            PlayersContext.Players.Include(player => player.PlayerStats);

        public virtual IQueryable<Player> All()
        {
            return PlayersIncluded;
        }

        public virtual Player FindById(String id)
        {
            return FindByIdAsync(id).Result;
        }

        public virtual async Task<Player> FindByIdAsync(string id)
        {
            return await PlayersIncluded.FirstOrDefaultAsync(player => player.ID == id);
        }
        
        public virtual Player FindByName(string name)
        {
            return FindByNameAsync(name).Result;
        }
        
        public virtual async Task<Player> FindByNameAsync(string name)
        {
            return await PlayersIncluded.FirstOrDefaultAsync(player => player.Name == name);
        }

        public virtual Player GetOrCreate(string name)
        {
            return FindByName(name) ?? Create(name);
        }

        public virtual Player Create(string name)
        {
            var player = new Player()
            {
                Name = name,
                PlayerStats = new Stats()
            };

            player.PlayerStats.Player = player;

            return player;
        }

        public virtual void Save(Player player)
        {
            player = string.IsNullOrEmpty(player.ID) ? 
                PlayersContext.Add(player).Entity : 
                PlayersContext.Update(player).Entity;

            if (string.IsNullOrEmpty(player.PlayerStats.PlayerId))
            {
                player.PlayerStats.PlayerId = player.ID;
                player.PlayerStats.Player = player;
                PlayersContext.Update(player.PlayerStats);
            }
            else
            {
                PlayersContext.Update(player.PlayerStats);
            }
            
            PlayersContext.SaveChanges();
        }
        
    }
}