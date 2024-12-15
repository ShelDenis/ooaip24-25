using App;
using SpaceBattle.Lib;

public class RegisterIoCDependencyActionsStart: SpaceBattle.Lib.ICommand
{
    public void Execute()
    {
        Ioc.Resolve<App.ICommand>(
            "Ioc.Register",
            "Actions.Start",
            (object[] args) => new StartCommand((string)args[0], (object[])args[1], (string)args[2])
        ).Execute();
    }
}