using System;
using System.Linq;
using xCLI;
using Xunit;

namespace TestxCLI
{
    public class TestCliControllerHost
    {
        [Fact]
        public void Controller_Not_Abstract()
        {
            var host = new CliControllerHost();
            Assert.Throws<ArgumentException>(() =>
            {
                host.RegisterController<AbstractController>();
            });
        }

        [Fact]
        public void Controller_Not_Static()
        {
            var host = new CliControllerHost();
            Assert.Throws<ArgumentException>(() =>
            {
                host.RegisterController(typeof(StaticController));
            });
        }

        [Fact]
        public void Get_Registered_Controllers()
        {
            var host = new CliControllerHost();
            host.RegisterController<ExampleControllerA>();
            host.RegisterController<ExampleControllerB>();

            Type[] expectedControllers = new[] { typeof(ExampleControllerA),
                                                 typeof(ExampleControllerB) };
            Type[] controllers = host.Controllers.OrderBy(x => x.Name)
                                                 .ToArray();
            Assert.Equal(expectedControllers, controllers);
        }

        public class UndecoratedController { }

        [CliController("example")]
        public static class StaticController { }

        [CliController("example")]
        public abstract class AbstractController { }

        [CliController("example")]
        public class ExampleControllerA { }

        [CliController("example")]
        public class ExampleControllerB { }
    }
}
