using App;
namespace SpaceBattle.Lib;

public class StopCommand : ICommand
{
    private readonly string action;
    private readonly string key;
    public StopCommand(IDictionary<string, object> order)
    {
        action = (string)order["Action"];
        key = (string)order["Key"];
    }
    public void Execute()
    {
        var gameObject = Ioc.Resolve<IDictionary<string, object>>("Game.Object", key);
        var inj = (ICommandInjectable)gameObject[action];
        var empty = Ioc.Resolve<ICommand>("Commands.Empty");

        inj.Inject(empty);
    }
}

