using App;

namespace SpaceBattle.Lib;

public class StartCommand : ICommand
{
    string action;
    object[] args;
    string key;
    public StartCommand(Dictionary<string, object> order)
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
        var RepeatableMacro = new MCommand([mc, inj]);
        var repeatcmd = Ioc.Resolve<ICommand>("Commands.Send", q, RepeatableMacro);
        var inj_injectable = (ICommandInjectable)inj;
        inj_injectable.Inject(repeatcmd);
        var sendcmd = Ioc.Resolve<ICommand>("Commands.Send", q, repeatcmd);
        sendcmd.Execute();
        var objs = Ioc.Resolve<IDictionary<string, IDictionary<string, object>>>("Game.Objects");
        objs[key].Add(action, inj);
    }
}