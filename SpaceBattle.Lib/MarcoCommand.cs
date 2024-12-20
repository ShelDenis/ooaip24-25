namespace SpaceBattle.Lib;

public class MCommand : ICommand
{
    private readonly ICommand[] cmds;
    public MCommand(ICommand[] cmds)
    {
        this.cmds = cmds;
    }

    public void Execute()
    {
        List<ICommand> ic_list = new List<ICommand>();
        ic_list = cmds.ToList<ICommand>();
        ic_list.ForEach(c => c.Execute());
    }
}
