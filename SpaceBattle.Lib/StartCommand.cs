using App;

namespace SpaceBattle.Lib;

public class StartCommand: ICommand
{
    string name;
    object[] args;
    string key;
    public StartCommand(string name, object[] args, string key)
    {
        this.name = name;
        this.args = args;
        this.key = key;
    }

    public void Execute()
    {
        var mc = Ioc.Resolve<ICommand>("Macro." + name, args);
        var inj = Ioc.Resolve<ICommandInjectable>("Commands.CommandInjectable");
        inj.Inject(mc);
        var q = Ioc.Resolve<ICommandReceiver>("Game.Queue");
        var sendcmd = Ioc.Resolve<ICommand>("Commands.Send", q, inj);
        sendcmd.Execute();
        var objs = Ioc.Resolve<IDictionary<string, IDictionary<string, object>>>("Game.Objects");
        objs[key].Add(name, inj);
    }
}