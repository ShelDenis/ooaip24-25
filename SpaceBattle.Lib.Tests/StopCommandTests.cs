using App;
using App.Scopes;
using Moq;
using Xunit;
namespace SpaceBattle.Lib;

public class StopCommandTests
{
    public StopCommandTests()
    {
        new InitCommand().Execute();
        var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
        Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();
    }

    [Fact]
    public void StopCmdTest()
    {
        var mockInj = new Mock<ICommandInjectable>();
        var mockEmpty = new Mock<ICommand>();

        var obj = new Mock<IDictionary<string, object>>();

        Ioc.Resolve<App.ICommand>("IoC.Register", "Commands.Injectable", (object[] args) => mockInj.Object).Execute();
        Ioc.Resolve<App.ICommand>("IoC.Register", "Commands.Empty", (object[] args) => mockEmpty.Object).Execute();

        var stopCommand = new StopCommand(obj.Object);
        stopCommand.Execute();
        mockInj.Verify(i => i.Inject(mockEmpty.Object), Times.Once);
    }
}