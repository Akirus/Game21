using System;
using System.Collections.Generic;
using System.Linq;
using Game21.Service.Configuration.Routes;
using Microsoft.Extensions.Configuration;

namespace Game21.Service.Configuration
{
    public class ApplicationConfiguration
    {
        private IConfigurationRoot ConfigurationRoot { get; }
        
        public ApplicationConfiguration(IConfigurationRoot root)
        {
            ConfigurationRoot = root;
        }

        public IEnumerable<RouteInfo> Routes
        {
            get
            {
                foreach (var child in ConfigurationRoot.GetSection("Routes").GetChildren())
                {
                    Dictionary<string, string> defaults = child.GetSection("defaults")?.GetChildren()?.ToDictionary(
                        section => section.Key,
                        section => section.Value);

                    yield return new RouteInfo(child.GetValue("name", "default"),
                        child.GetValue<string>("template"), defaults);
                }
            }
        }

        public string DefaultConnection =>
            ConfigurationRoot.GetConnectionString("DefaultConnection");

        public string CacheConnection => DefaultConnection;
        
        public IConfigurationSection Logging => ConfigurationRoot.GetSection("Logging");
    }

}