namespace Globo.Calculator.Expressions
{
    using Autofac;

    public class ExpressionModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<InfixToPostfixExpressionTransformer>().As<IExpressionTransformer>().InstancePerLifetimeScope();
            builder.RegisterType<ExpressionBuilder>().As<IExpressionBuilder>().InstancePerLifetimeScope();
        }
    }
}