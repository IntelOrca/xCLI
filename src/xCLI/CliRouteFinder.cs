using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace xCLI
{
    /// <summary>
    /// Searches CLI controllers for an action that matches a set of arguments.
    /// </summary>
    public class CliRouteFinder
    {
        private readonly ICliControllerHost _controllerHost;
        private readonly CliOptions _cliOptions;

        public CliRouteFinder(ICliControllerHost controllerHost, CliOptions cliOptions)
        {
            _controllerHost = controllerHost;
            _cliOptions = cliOptions;
        }

        public ICliAction Match(string[] args)
        {
            List<ICliAction> routes = GetAllRoutes();
            foreach (ICliAction cliAction in routes)
            {
                if (IsMatch(cliAction, args))
                {
                    return cliAction;
                }
            }

            return null;
        }

        private bool IsMatch(ICliAction cliAction, string[] args)
        {
            string[] routeArgs = cliAction.Route.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int argIndex = 0;
            foreach (string routeArg in routeArgs)
            {
                if (routeArg.StartsWith("{"))
                {
                    continue;
                }

                if (args.Length <= argIndex)
                {
                    return false;
                }

                if (routeArg != args[argIndex])
                {
                    return false;
                }
                argIndex++;
            }

            return true;
        }

        private List<ICliAction> GetAllRoutes()
        {
            var cliActions = new List<ICliAction>();
            foreach (Type type in _controllerHost.Controllers)
            {
                IEnumerable<ICliAction> routes = GetRoutes(type);
                cliActions.AddRange(routes);
            }
            return cliActions;
        }

        private IEnumerable<ICliAction> GetRoutes(Type controller)
        {
            const BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Public;
            MethodInfo[] methods = controller.GetTypeInfo()
                                             .GetMethods(bindingFlags);

            foreach (MethodInfo mi in methods)
            {
                var routeAttribute = mi.GetCustomAttribute<CliRouteAttribute>();
                if (routeAttribute != null)
                {
                    string route = routeAttribute.Route;
                    if (route == null)
                    {
                        // Use the method name as the route
                        route = mi.Name;
                    }

                    var cliAction = new CliAction(controller, mi, route);
                    yield return cliAction;
                }
            }
        }
    }
}
