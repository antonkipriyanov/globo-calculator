namespace Globo.Calculator.Host.Application
{
    using Autofac;
    using Globo.Commands.Commands;

    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new CommandModule(new[] {ThisAssembly}));
            builder.RegisterType<Application>().As<IApplication>().InstancePerLifetimeScope();
        }
    }
}