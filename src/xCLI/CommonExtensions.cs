namespace xCLI
{
    public static class CommonExtensions
    {
        public static void RegisterController<T>(this ICliControllerHost cliControllerHost)
        {
            cliControllerHost.RegisterController(typeof(T));
        }
    }
}
