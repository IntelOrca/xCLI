using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xCLI
{
    [AttributeUsage(AttributeTargets.Property |
                    AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class CliOptionAttribute : Attribute
    {
        public char ShortName { get; }
        public string LongName { get; }

        public CliOptionAttribute()
        {
        }

        public CliOptionAttribute(char shortName)
        {
            ShortName = shortName;
        }

        public CliOptionAttribute(string longName)
        {
            LongName = longName;
        }

        public CliOptionAttribute(char shortName, string longName)
        {
            ShortName = shortName;
            LongName = longName;
        }
    }
}
