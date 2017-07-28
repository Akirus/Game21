using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Game21.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}