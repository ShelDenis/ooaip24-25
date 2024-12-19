using
namespace SpaceBattle.Lib;

public class StopCommand: ICommand
{
    public void Execute()
    {
        var injectable = Ioc.Resolve<ICommandInjectable>("Game.Object.GetInjectable", objectId, commandName);
    }
}

