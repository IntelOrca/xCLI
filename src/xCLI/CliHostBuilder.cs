namespace xCLI
{
    public class CliHostBuilder
    {
        private readonly CliControllerHost _cliControllerHost = new CliControllerHost();
        private readonly CliOptions _cliOptions = new CliOptions();

        public CliHostBuilder()
        {
        }

        /// <summary>
        /// Registers all CLI controllers that are decorated with
        /// <see cref="CliControllerAttribute"/>.
        /// </summary>
        public CliHostBuilder RegisterByAttribute()
        {
            _cliControllerHost.RegisterAllControllersWithAttribute();
            return this;
        }

        public ICliHost Build()
        {
            return new CliHost(_cliControllerHost, _cliOptions);
        }
    }
}
