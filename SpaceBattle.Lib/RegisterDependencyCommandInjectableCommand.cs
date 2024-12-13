using App;
namespace SpaceBattle.Lib;

public class RegisterDependencyCommandInjectableCommand
{
    public void Execute()
    {
        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            "Commands.CommandInjectable",
            (object[] args) => new InjectableCommand()
        ).Execute();
    }
}