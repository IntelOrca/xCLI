using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace xCLI
{
    public interface ICliAction
    {
        Type Controller { get; }
        MethodInfo Method { get; }
        string Route { get; }
    }

    internal class CliAction : ICliAction
    {
        public Type Controller { get; }
        public MethodInfo Method { get; }
        public string Route { get; }

        public CliAction(Type controller, MethodInfo method, string route)
        {
            Controller = controller;
            Method = method;
            Route = route;
        }
    }
}
