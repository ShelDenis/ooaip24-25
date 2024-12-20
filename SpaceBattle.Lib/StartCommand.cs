using App;

namespace SpaceBattle.Lib;

public class StartCommand : ICommand
{
    private readonly string action;
    private readonly object[] args;
    private readonly string key;
    public StartCommand(IDictionary<string, object> order)
    {
        action = (string)order["Action"];
        args = (object[])order["Args"];
        key = (string)order["Key"];
    }

    public void Execute()
    {
        var mc = Ioc.Resolve<ICommand>("Macro." + action, args);
        var inj = Ioc.Resolve<ICommand>("Commands.CommandInjectable");
        var q = Ioc.Resolve<ICommandReceiver>("Game.Queue");
        var RepeatableMacro = Ioc.Resolve<ICommand>("Commands.Macro", (ICommand[])[mc, inj]);
        var repeatCommand = Ioc.Resolve<ICommand>("Commands.Send", q, RepeatableMacro);
        var injInjectable = (ICommandInjectable)inj;
        injInjectable.Inject(repeatCommand);
        var sendCommand = Ioc.Resolve<ICommand>("Commands.Send", q, repeatCommand);
        sendCommand.Execute();
        var obj = Ioc.Resolve<IDictionary<string, object>>("Game.Object", key);
        obj.Add(action, inj);
    }
}
