using System;
using xCLI;
using Xunit;

namespace TestxCLI
{
    public class TestCliControllerHost
    {
        [Fact]
        public void Controller_Is_Decorated()
        {
            var host = new CliControllerHost();
            Assert.Throws<ArgumentException>(() =>
            {
                host.RegisterController<UndecoratedController>();
            });
        }

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
        public void Controller_Detect_Type_Conflict()
        {
            var host = new CliControllerHost();
            Assert.Throws<ArgumentException>(() =>
            {
                host.RegisterController<ExampleControllerA>();
                host.RegisterController<ExampleControllerA>();
            });
        }

        [Fact]
        public void Controller_Detect_Command_Conflict()
        {
            var host = new CliControllerHost();
            Assert.Throws<ArgumentException>(() =>
            {
                host.RegisterController<ExampleControllerA>();
                host.RegisterController<ExampleControllerB>();
            });
        }

        [Fact]
        public void Get_Registered_Controller_Exist()
        {
            var host = new CliControllerHost();
            host.RegisterController<ExampleControllerA>();
            Type controllerType = host.GetRegisteredController("example");

            Assert.Equal(typeof(ExampleControllerA), controllerType);
        }

        [Fact]
        public void Get_Registered_Controller_NotExist()
        {
            var host = new CliControllerHost();
            host.RegisterController<ExampleControllerA>();
            Type controllerType = host.GetRegisteredController("other");

            Assert.Null(controllerType);
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
