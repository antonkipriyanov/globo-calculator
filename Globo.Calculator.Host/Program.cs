namespace Globo.Calculator.Host
{
    using Application;
    using Autofac;

    public class Program
    {
        private static void Main(string[] args)
        {
            var container = Bootstrapper.Run();

            using (var lifetimeScope = container.BeginLifetimeScope())
            {
                var application = lifetimeScope.Resolve<IApplication>();

                application.Run();
            }
        }
    }
}