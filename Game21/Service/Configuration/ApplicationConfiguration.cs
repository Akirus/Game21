using System;
using System.Collections.Generic;
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
                foreach(var child in ConfigurationRoot.GetSection("Routes").GetChildren())
                {
                    yield return new RouteInfo(child.GetValue("name", "default"), 
                        child.GetValue<string>("template"));
                }
            }
        }

        public string DefaultConnection =>
            ConfigurationRoot.GetConnectionString("DefaultConnection");

        public IConfigurationSection Logging => ConfigurationRoot.GetSection("Logging");
    }

}