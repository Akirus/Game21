using System;
using System.Linq;
using System.Threading.Tasks;
using Game21.Data;
using Game21.Data.Models;
using Game21.Models;
using Game21.Service.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Game21.Controllers
{
    public class TestController : BaseController
    {
        
        public PlayersContext PlayersContext { get; set; }

        public TestController(PlayersContext playerContext)
        {
            PlayersContext = playerContext;
        }
        
        // GET
        public IActionResult Index([FromServices] ApplicationConfiguration configuration)
        {
            return Fine("Okay!!");
        }

        public async Task<IActionResult> Players()
        {
            return Fine(await PlayersContext.Players.Include(player => player.PlayerStats).ToListAsync());
        }

        public async Task<IActionResult> UpdatePlayer(string id)
        {
            Player player = await PlayersContext.Players
                .Include(p => p.PlayerStats)
                .FirstOrDefaultAsync(p => p.ID == id);

            if (player != null)
            {
                player.PlayerStats.LastVisit = DateTimeOffset.Now;
                player.PlayerStats.TotalVisits++;

                PlayersContext.Update(player);
                await PlayersContext.SaveChangesAsync();

                return Fine(player);
            }
            
            return Fail($"Cannot find player with id: {id}");
        }

        public async Task<IActionResult> CreatePlayer(string name)
        {
            ApplicationResult result = new ApplicationResult();

            var entity = (await PlayersContext.Players.AddAsync(new Player()
            {
                Name = name
            })).Entity;
            
            entity.PlayerStats = new Stats()
            {
                Player = entity
            };

            await PlayersContext.AddAsync(entity);
                        
            var numberWritten = await PlayersContext.SaveChangesAsync();
            if (numberWritten >= 0)
            {
                result.Result = entity;
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.ErrorMessages = Enumerable.Repeat("Failed to add", 1);
            }

            return Result(result);
        }
        
    }
}