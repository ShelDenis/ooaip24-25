using App;
using App.Scopes;
using Xunit;

namespace SpaceBattle.Lib;

public class RegisterIoCDependencyEmptyCommandTests
    {
        [Fact]
        public void EmptyCommandIoCTest()
        {
            new InitCommand().Execute();
            var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
            Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();

            var registerEmpty = new RegisterIoCDependencyEmptyCommand();

            registerEmpty.Execute();
            var res = Ioc.Resolve<ICommand>("Commands.Empty");

            Assert.IsType<EmptyCommand>(res);
        }
    }