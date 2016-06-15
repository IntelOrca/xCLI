using System;
using System.Collections.Generic;
using System.Reflection;
using xCLI.Extensions;

namespace xCLI
{
    internal class CliControllerHost : ICliControllerHost
    {
        private Dictionary<string, Type> _controllers = new Dictionary<string, Type>();

        public void RegisterController<T>()
        {
            RegisterController(typeof(T));
        }

        public void RegisterController(Type type)
        {
            CliControllerAttribute controllerAttribute;
            if (!type.TryGetAttribute(out controllerAttribute))
            {
                throw new ArgumentException($"{type} is not decorated with CliControllerAttribute.", nameof(type));
            }

            if (type.GetTypeInfo().IsAbstract)
            {
                throw new ArgumentException($"{type} can not be abstract.", nameof(type));
            }

            string commandText = controllerAttribute.Command;

            if (_controllers.ContainsKey(commandText))
            {
                throw new ArgumentException($"The command {commandText} already has a registered controller.");
            }

            _controllers.Add(commandText, type);
        }

        public Type GetRegisteredController(string command)
        {
            Type type = null;
            _controllers.TryGetValue(command, out type);
            return type;
        }
    }
}
