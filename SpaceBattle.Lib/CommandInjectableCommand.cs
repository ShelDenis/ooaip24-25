namespace SpaceBattle.Lib;

public class InjectableCommand : ICommand, ICommandInjectable
{
    private ICommand _cmd = new EmptyCommand();
    public void Execute()
    {
        if (_cmd.GetType() == typeof(EmptyCommand))
        {
            throw new Exception("There is nothing to execute!");
        }

        _cmd.Execute();
    }
    public void Inject(ICommand cmd)
    {
        _cmd = cmd;
    }
}
