namespace Globo.Calculator.Host
{
    using Application;
    using Autofac;
    using Expressions;
    using Serilog;

    public static class Bootstrapper
    {
        public static IContainer Run()
        {
            return ConfigureContainer();
        }

        private static IContainer ConfigureContainer()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<ExpressionModule>();
            containerBuilder.RegisterModule<ApplicationModule>();

            ConfigureLogging(containerBuilder);

            return containerBuilder.Build();
        }

        private static void ConfigureLogging(ContainerBuilder containerBuilder)
        {
            containerBuilder.Register<ILogger>((c, p) => new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger()).SingleInstance();
        }
    }
}