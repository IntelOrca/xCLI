using System;
using System.Reflection;

namespace xCLI
{
    public class CliHost : ICliHost
    {
        private readonly ICliControllerHost _controllerHost;
        private readonly CliOptions _cliOptions;

        public CliHost(ICliControllerHost controllerHost, CliOptions cliOptions)
        {
            _controllerHost = controllerHost;
            _cliOptions = cliOptions;
        }

        public int Run(string[] args)
        {
            var routeFinder = new CliRouteFinder(_controllerHost, _cliOptions);
            ICliAction cliAction = routeFinder.Match(args);
            if (cliAction == null)
            {
                return 0;
            }
            else
            {
                MethodInfo mi = cliAction.Method;
                ParameterInfo[] miParameters = mi.GetParameters();

                ICommandLineArguments commandLineArgs = new CommandLineArguments();

                var controllerFactory = new CliControllerFactory();
                CliControllerInstance controllerInstance =
                    controllerFactory.CreateController(cliAction.Controller, commandLineArgs);

                object[] methodArgs = new object[miParameters.Length];
                object result = mi.Invoke(controllerInstance.Instance, methodArgs);
                if (result is bool)
                {
                    return (bool)result ? 0 : 1;
                }
                else
                {
                    try
                    {
                        return Convert.ToInt32(result);
                    }
                    catch
                    {
                        return 0;
                    }
                }
            }
        }
    }
}
