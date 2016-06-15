using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xCLI
{
    public class CliOptions
    {
        /// <summary>
        /// Whether or not to ignore the case for command routing.
        /// </summary>
        public bool CaseSensitiveCommands { get; set; } = true;

        /// <summary>
        /// Whether or not to ignore the case for options.
        /// </summary>
        public bool CaseSensitiveOptions { get; set; } = true;

        /// <summary>
        /// Automatically uses the first character of the long name or option
        /// name for its short name if unique.
        /// </summary>
        public bool ImplicitShortNames { get; set; } = false;

        /// <summary>
        /// Automatically use the name of the parameter or property for the
        /// option's long name.
        /// </summary>
        public bool ImplicitLongNames { get; set; } = true;
    }
}
