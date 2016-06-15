using System;

namespace xCLI
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
    public class CliRouteAttribute : Attribute
    {
        public string Route { get; }

        public CliRouteAttribute()
        {
        }

        public CliRouteAttribute(string route)
        {
            Route = route;
        }
    }
}
