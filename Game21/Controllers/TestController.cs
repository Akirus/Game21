using Game21.Service.Configuration;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Game21.Controllers
{
    public class TestController : Controller
    {
        // GET
        public IActionResult Index([FromServices] ApplicationConfiguration configuration)
        {
            return Json(new
            {
                Message = "HEllo"
            });
        }

        
    }
}