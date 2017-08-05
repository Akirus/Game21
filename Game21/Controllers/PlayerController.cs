using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Game21.Data;
using Game21.Data.Models;
using Game21.Models;
using Game21.Service;
using Game21.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Newtonsoft.Json;

namespace Game21.Controllers
{
    public class PlayerController : BaseController
    {
        
        private PlayerRepository Repository { get; }
        private PlayerService PlayerService { get; }

        public PlayerController(PlayerRepository repository, PlayerService playerService, ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            Repository = repository;
            PlayerService = playerService;
        }

        [HttpPost]
        public IActionResult Logout()
        {
            PlayerService.Logout();
            return Fine("Success!");
        }
        
        [HttpPost]
        public async Task<IActionResult> Login([DataType(DataType.Text)] string name)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Player player = await PlayerService.LoginAsync(name);
                    return Fine(player);
                }
                catch (Exception e)
                {
                    Logger.LogError(e);
                    return Fail("Internal Error!");
                }
            }
            
            return Fail();
        }

        public IActionResult Current()
        {
            try
            {
                return Fine(PlayerService.Current);
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                return Fail("Internal Error!");
            }
        }

        public IActionResult List(PaginationModel model)
        {
            try
            {
                var result = Repository.All().Skip((int) (model.PageNumber * model.PageSize))
                    .Take((int) model.PageSize);

                Logger.LogInformation($"PageNumber: {model.PageNumber}; PageSize: {model.PageSize}");

                if (result.Any())
                {
                    return Fine(result,
                        $"Displaying results from {model.PageNumber * model.PageSize + 1} " +
                        $"to {model.PageNumber * model.PageSize + result.Count()}");
                }

                return Fine(result, "There is no users in repository");
            }
            catch (Exception e)
            {
                Logger.LogError(e);
                return Fail("Internal Error!");
            }
        }
    }
}