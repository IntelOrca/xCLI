using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using xCLI.Extensions;

namespace xCLI
{
    internal class CliControllerHost : ICliControllerHost
    {
        private List<Type> _controllers = new List<Type>();

        public IReadOnlyCollection<Type> Controllers
        {
            get
            {
                return new ReadOnlyCollection<Type>(_controllers);
            }
        }

        public void RegisterController<T>()
        {
            RegisterController(typeof(T));
        }

        public void RegisterController(Type type)
        {
            if (type.GetTypeInfo().IsAbstract)
            {
                throw new ArgumentException($"{type} can not be abstract.", nameof(type));
            }

            _controllers.Add(type);
        }

        public void RegisterAllControllersWithAttribute()
        {
            Type[] exportedTypes = Assembly.GetEntryAssembly()
                                           .GetExportedTypes();
            foreach (Type type in exportedTypes)
            {
                CliControllerAttribute controllerAttribute;
                if (type.TryGetAttribute(out controllerAttribute))
                {
                    RegisterController(type);
                }
            }
        }
    }
}
