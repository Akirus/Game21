using System;
using System.Linq;
using Game21.Data;
using Game21.Models;
using Game21.Service;
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

        public IActionResult Login(string name)
        {
            //TODO implement login staff
            
            return Fine("");
        }

        public IActionResult Current()
        {
            return Fine(PlayerService.Current);
        }

        public IActionResult List(PaginationModel model)
        {
            var result = Repository.All().
                Skip((int) (model.PageNumber * model.PageSize)).
                Take((int) model.PageSize);
            
            Logger.LogInformation($"PageNumber: {model.PageNumber}; PageSize: {model.PageSize}");
            
            if (result.Any())
            {
                return Fine(result,
                    $"Displaying results from {model.PageNumber * model.PageSize + 1} " +
                    $"to {model.PageNumber * model.PageSize + result.Count()}");
            }
            
            return Fine(result, "There is no users in repository");
        }
    }
}