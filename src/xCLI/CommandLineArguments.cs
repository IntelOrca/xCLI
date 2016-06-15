using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xCLI
{
    public class CommandLineArguments : ICommandLineArguments
    {
        public string[] GetArguments()
        {
            throw new NotImplementedException();
        }

        public T GetArgumentsAs<T>()
        {
            throw new NotImplementedException();
        }

        public T GetOptionAs<T>(char shortName)
        {
            throw new NotImplementedException();
        }

        public string GetOptionValue(char shortName)
        {
            throw new NotImplementedException();
        }

        public string[] GetOptionValues(char shortName)
        {
            throw new NotImplementedException();
        }

        public bool GetSwitch(string longName)
        {
            throw new NotImplementedException();
        }

        public bool GetSwitch(char shortName)
        {
            throw new NotImplementedException();
        }
    }
}
