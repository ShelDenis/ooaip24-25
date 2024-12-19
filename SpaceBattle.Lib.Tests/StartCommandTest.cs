using App;
using App.Scopes;
using Xunit;
namespace SpaceBattle.Lib;

public class StartCommandTest
{
    [Fact]
    public void StartCommandExecuteTest()
    {
        new InitCommand().Execute();
        var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
        Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();

    }
}
