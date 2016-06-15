using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xCLI
{
    public interface ICommandLineArguments
    {
        bool GetSwitch(char shortName);
        bool GetSwitch(string longName);

        string GetOptionValue(char shortName);
        string[] GetOptionValues(char shortName);
        T GetOptionAs<T>(char shortName);

        string[] GetArguments();
        T GetArgumentsAs<T>();
    }
}
