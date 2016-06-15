using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace xCLI
{
    /// <summary>
    /// Creates an instance of a controller and satisfies its dependencies and options.
    /// </summary>
    internal class CliControllerFactory
    {
        public CliControllerFactory()
        {

        }

        public CliControllerInstance CreateController(Type controller, ICommandLineArguments commandLineArgs)
        {
            object instance = Activator.CreateInstance(controller);
            var controllerInstance = new CliControllerInstance(controller, instance);

            SatisfyProperties(controllerInstance, commandLineArgs);

            return controllerInstance;
        }

        private void SatisfyProperties(CliControllerInstance controller, ICommandLineArguments commandLineArgs)
        {
            const BindingFlags bindingFlags = BindingFlags.GetProperty |
                                              BindingFlags.SetProperty |
                                              BindingFlags.Public |
                                              BindingFlags.Instance;
            PropertyInfo[] properties = controller.Type.GetTypeInfo()
                                                       .GetProperties(bindingFlags);

            foreach (PropertyInfo property in properties)
            {
                SatisfyProperty(controller, commandLineArgs, property);
            }
        }

        private void SatisfyProperty(CliControllerInstance controller,
                                     ICommandLineArguments commandLineArgs,
                                     PropertyInfo property)
        {
            CliSwitchAttribute switchAttribute = property.GetCustomAttribute<CliSwitchAttribute>();
            if (switchAttribute != null)
            {
                bool switchExists = false;
                switchExists |= commandLineArgs.GetSwitch(switchAttribute.ShortName);
                switchExists |= commandLineArgs.GetSwitch(switchAttribute.LongName);

                property.SetValue(controller.Instance, switchExists);
            }
        }
    }

    internal class CliControllerInstance
    {
        public Type Type { get; }
        public object Instance { get; }

        public CliControllerInstance(Type type, object instance)
        {
            Type = type;
            Instance = instance;
        }
    }
}
