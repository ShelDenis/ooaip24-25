using Xunit;
using Moq;
using App;
using App.Scopes;

namespace SpaceBattle.Lib;

public class SendCommandRegisterTest
{
    [Fact]
    public void ExecuteTest() 
    {
        new InitCommand().Execute();
        var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
        Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();

        var mock_rec = new Mock<ICommandReceiver>();
        var mock_cmd = new Mock<ICommand>();

        var registerSend = new RegisterIoCDependencySendCommand();
        registerSend.Execute();

        var sendcom = Ioc.Resolve<ICommand>("Commands.Send", mock_cmd.Object, mock_rec.Object);

        Assert.IsType<SendCommand>(sendcom);

    }
}