namespace Globo.Calculator.Host.Application
{
    using System;
    using Autofac;
    using Commands;
    using Globo.Commands.Commands;
    using Globo.Commands.Results;
    using Serilog;

    public class Application : IApplication
    {
        private readonly ILifetimeScope lifetimeScope;
        private readonly ILogger logger;

        public Application(ILifetimeScope lifetimeScope)
        {
            this.lifetimeScope = lifetimeScope;
            logger = lifetimeScope.Resolve<ILogger>();
        }

        public void Run()
        {
            Console.WriteLine("Enter expression. Print 'exit' to finish.");

            while (true)
            {
                var input = Console.ReadLine();

                if (input?.ToLowerInvariant() == "exit")
                {
                    break;
                }

                try
                {
                    var command = new EvaluateExpressionCommand(input);

                    var result = ExecuteCommand(command);

                    if (result.Success)
                    {
                        Console.WriteLine($"Result: {command.Result:0.##}");
                    }
                    else
                    {
                        Console.WriteLine("Errors:");
                        foreach (var error in result.Errors)
                        {
                            Console.WriteLine(error);
                        }
                    }
                }
                catch (Exception e)
                {
                    logger.Debug(e, "An error ocurred during evaluation");
                    Console.WriteLine("Looks like something wrong with your expression.");
                }
            }
        }

        private IExecutionResult ExecuteCommand<T>(T command) where T : ICommand
        {
            using (var scope = lifetimeScope.BeginLifetimeScope())
            {
                var handler = scope.Resolve<ICommandHandler<T>>(new TypedParameter(typeof(T), command));

                return handler.Execute();
            }
        }
    }
}