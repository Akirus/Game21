namespace Game21.Service.Configuration
{
    public class RouteInfo
    {
        public string Name { get; set; }
        public string Template { get; set; }

        public RouteInfo(string name, string template)
        {
            this.Name = name;
            this.Template = template;
        }
        
    } 
}