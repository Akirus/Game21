using System.Threading.Tasks;
using Game21.Data;
using Game21.Data.Models;
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
            return Fine(await PlayersContext.Players.ToListAsync());
        }

        public async Task<IActionResult> CreatePlayer(string name)
        {
            await PlayersContext.Players.AddAsync(new Player()
            {
                Name = name
            });

            await PlayersContext.SaveChangesAsync();

            return Fine("Created!");
        }
        
    }
}