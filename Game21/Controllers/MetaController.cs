using Game21.Service.Configuration;
using Microsoft.AspNetCore.Mvc;

namespace Game21.Controllers
{
    
    public class MetaController : Controller
    {
        [ActionName("config")]
        public IActionResult Configurations([FromServices] ApplicationConfiguration configuration)
        {
            return Json(configuration);
        }
    }
}