using System;
using System.Collections.Generic;

namespace Game21.Service.Configuration.Routes
{
    public class RouteInfo
    {
        public string Name { get; set; }
        public string Template { get; set; }

        public Dictionary<String, String> Defaults { get; set; }

        public RouteInfo(string name, string template, Dictionary<String, String> defaults = null)
        {
            this.Name = name;
            this.Template = template;
            
            if(defaults == null)
                defaults = new Dictionary<string, string>();

            Defaults = defaults;
        }
        
    } 
}