namespace Globo.Commands.Commands
{
    using System.Reflection;
    using Autofac;
    using Module = Autofac.Module;

    public class CommandModule : Module
    {
        private readonly Assembly[] handlerAssemblies;

        public CommandModule(Assembly[] handlerAssemblies)
        {
            this.handlerAssemblies = handlerAssemblies;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(handlerAssemblies)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PreserveExistingDefaults();
        }
    }
}