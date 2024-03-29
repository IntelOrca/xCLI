﻿using System;

namespace xCLI
{
    [AttributeUsage(AttributeTargets.Property |
                    AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class CliSwitchAttribute : Attribute
    {
        public char ShortName { get; }
        public string LongName { get; }

        public CliSwitchAttribute()
        {
        }

        public CliSwitchAttribute(char shortName)
        {
            ShortName = shortName;
        }

        public CliSwitchAttribute(string longName)
        {
            LongName = longName;
        }

        public CliSwitchAttribute(char shortName, string longName)
        {
            ShortName = shortName;
            LongName = longName;
        }
    }
}
