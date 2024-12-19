using App;

namespace SpaceBattle.Lib;

public class StartCommand : ICommand
{
    string action;
    object[] args;
    string key;
    public StartCommand(IDictionary<string, object> order)
    {
        this.action = (string)order["Action"];
        this.args = (object[])order["Args"];
        this.key = (string)order["Key"];
    }

    public void Execute()
    {
        var mc = Ioc.Resolve<ICommand>("Macro." + action, args);
        var inj = Ioc.Resolve<ICommand>("Commands.CommandInjectable");
        var q = Ioc.Resolve<ICommandReceiver>("Game.Queue");
        var RepeatableMacro = Ioc.Resolve<ICommandReceiver>("Commands.Macro", [mc, inj]);
        var repeatcmd = Ioc.Resolve<ICommand>("Commands.Send", q, RepeatableMacro);
        var inj_injectable = (ICommandInjectable)inj;
        inj_injectable.Inject(repeatcmd);
        var sendcmd = Ioc.Resolve<ICommand>("Commands.Send", q, repeatcmd);
        sendcmd.Execute();
        var obj = Ioc.Resolve<IDictionary<string, object>>("Game.Object", key);
        obj.Add(action, inj);
    }
}