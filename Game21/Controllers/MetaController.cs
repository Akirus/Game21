﻿using System.Linq;
using Game21.Service.Configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Game21.Controllers
{
    
    public class MetaController : BaseController
    {
        public MetaController(ILoggerFactory loggerFactory) : base(loggerFactory)
        {
        }
        
        public IActionResult Config([FromServices] ApplicationConfiguration configuration)
        {
            return Json(configuration);
        }

        public IActionResult Session([FromServices] IHttpContextAccessor accessor)
        {
            return Json(accessor.HttpContext.Session.IsAvailable);
        }

        public IActionResult Services([FromServices] IServiceCollection collection)
        {
            var result = collection.Select(service =>
                new
                {
                    Type = service.ServiceType?.FullName,
                    Lifetime = service.Lifetime.ToString(),
                    Instance = service.ImplementationType?.FullName
                });
            
            return Json(result, DefaultSerializerSettings);
        }

    }
}