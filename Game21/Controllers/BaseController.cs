using System;
using System.Linq;
using Game21.Models;
using Microsoft.AspNetCore.Mvc;

namespace Game21.Controllers
{
    public class BaseController : Controller
    {
        public IActionResult Result(ApplicationResult result) => Json(result);

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