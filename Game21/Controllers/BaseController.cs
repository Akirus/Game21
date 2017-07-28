using System;
using System.Linq;
using Game21.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Game21.Controllers
{
    public class BaseController : Controller
    {
        
        protected ILoggerFactory LoggerFactory { get; set; }

        private ILogger _logger;

        public ILogger Logger => _logger ?? 
                                 (_logger = LoggerFactory.CreateLogger(GetType().FullName));

        public BaseController(ILoggerFactory loggerFactory)
        {
            LoggerFactory = loggerFactory;
        }
        
        public JsonSerializerSettings DefaultSerializerSettings { get; } = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };
        
        public IActionResult Result(ApplicationResult result) => Json(result, DefaultSerializerSettings);

        public IActionResult Fine(object result, params string[] sucessMessages)
        {
            return Result(new ApplicationResult()
            {
                Result = result,
                ErrorMessages = Enumerable.Empty<string>(),
                Success = true,
                SuccessMessages = sucessMessages
            });
        }

        public IActionResult Fail(params string[] failMessages)
        {
            return Result(new ApplicationResult()
            {
                Result = null,
                ErrorMessages = failMessages,
                Success = false,
                SuccessMessages = Enumerable.Empty<string>()
            });
        }
        
    }
}