using Xunit;
using App;
using App.Scopes;
namespace SpaceBattle.Lib;

public class RegisterInjectableTests
{
    [Fact]
    public void CorrectExecutionTest()
    {
        new InitCommand().Execute();
        var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
        Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();

        var register_inject = new RegisterDependencyCommandInjectableCommand();
        register_inject.Execute();

        var exception1 = Record.Exception(() => Ioc.Resolve<ICommand>("Commands.CommandInjectable"));
        var exception2 = Record.Exception(() => Ioc.Resolve<ICommandInjectable>("Commands.CommandInjectable"));
        var exception3 = Record.Exception(() => Ioc.Resolve<InjectableCommand>("Commands.CommandInjectable"));

        Assert.Null(exception1);
        Assert.Null(exception2);
        Assert.Null(exception3);

    }
}