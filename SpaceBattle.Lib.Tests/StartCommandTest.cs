using Xunit;
using Moq;
using App;
using App.Scopes;
namespace SpaceBattle.Lib;

public class StartCommandTest
{
    public StartCommandTest()
    {
        new InitCommand().Execute();
        var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
        Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();
    } 

    [Fact]
    public void StartCommandExecuteTest()
    {
        var mCommand = new Mock<ICommand>();
        var inj = new Mock<ICommandInjectable>();
        var q = new Mock<ICommandReceiver>();
        var sendCommand = new Mock<ICommand>();

        Ioc.Resolve<App.ICommand>("IoC.Register", "Macro.Move", (object[] args) => mCommand.Object).Execute();
        Ioc.Resolve<App.ICommand>("IoC.Register", "Commands.CommadInjectable", (object[] args) => inj.Object).Execute();
        Ioc.Resolve<App.ICommand>("IoC.Register", "Game.Queue", (object[] args) => q.Object).Execute();
        Ioc.Resolve<App.ICommand>("IoC.Register", "Commands.Send", (object[] args) => sendCommand.Object).Execute();

        var obj = new Mock<IDictionary<string, object>>();

        var startCommand = new StartCommand(obj.Object);

        startCommand.Execute();

        inj.Verify(c => c.Inject(mCommand.Object), Times.Once);
        sendCommand.Verify(c => c.Execute(), Times.Once);
    }
}