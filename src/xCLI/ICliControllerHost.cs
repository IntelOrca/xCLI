using System;

namespace xCLI
{
    public interface ICliControllerHost
    {
        void RegisterController(Type type);
        Type GetRegisteredController(string command);
    }
}
