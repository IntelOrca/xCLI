using System;
using System.Collections.Generic;

namespace xCLI
{
    public interface ICliControllerHost
    {
        IReadOnlyCollection<Type> Controllers { get; }
        void RegisterController(Type type);
    }
}
