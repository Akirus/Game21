using Game21.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Game21.Data
{
    public class PlayersContext : DbContext
    {

        public PlayersContext(DbContextOptions<PlayersContext> options) : base(options)
        {
            
        }
        
        public DbSet<Player> Players { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>().ToTable("Players");
        }
    }
}