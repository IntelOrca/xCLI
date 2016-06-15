using System;

namespace xCLI
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = false)]
    public class CliControllerAttribute : Attribute
    {
        public string Command { get; }

        public CliControllerAttribute(string command)
        {
            Command = command;
        }
    }
}
