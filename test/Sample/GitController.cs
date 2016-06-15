using xCLI;

namespace Sample
{
    /// <summary>
    /// A CLI controller example based on git.
    /// </summary>
    [CliController]
    public class GitController
    {
        [CliSwitch('v', "verbose")]
        public bool Verbose { get; set; }

        [CliRoute("status {pathspec}")]
        public void Status(
            string[] pathspec,
            [CliSwitch('s', "short")] bool shortFormat,
            [CliSwitch('b')] bool branch,
            [CliSwitch] bool porcelain,
            [CliOption('u')] UntrackedFilesMode untrackedFiles,
            [CliSwitch] bool longFormat = true)
        {

        }

        public enum UntrackedFilesMode
        {
            No,
            Normal,
            All,
        }
    }
}
