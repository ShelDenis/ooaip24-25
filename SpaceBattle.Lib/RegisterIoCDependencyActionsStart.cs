using App;
namespace SpaceBattle.Lib;

public class RegisterIoCDependencyActionsStart : ICommand
{
    public void Execute()
    {
        Ioc.Resolve<App.ICommand>(
            "Ioc.Register",
            "Actions.Start",
            (object[] order) => new StartCommand((Dictionary<string, object>)order[0])
        ).Execute();
    }
}