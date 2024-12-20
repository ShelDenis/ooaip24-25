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
        var repeatcmd = Ioc.Resolve<ICommand>("Commands.Send", q, RepeatableMacro);
        var inj_injectable = (ICommandInjectable)inj;
        inj_injectable.Inject(repeatcmd);
        var sendcmd = Ioc.Resolve<ICommand>("Commands.Send", q, repeatcmd);
        sendcmd.Execute();
        var obj = Ioc.Resolve<IDictionary<string, object>>("Game.Object", key);
        obj.Add(action, inj);
    }
}
