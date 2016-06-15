using xCLI;

namespace Sample
{
    public class Program
    {
        public static int Main(string[] args)
        {
            ICliHost cliHost = new CliHostBuilder()
                .RegisterByAttribute()
                .Build();

            return cliHost.Run(args);
        }
    }
}
