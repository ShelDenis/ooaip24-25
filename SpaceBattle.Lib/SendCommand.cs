namespace SpaceBattle.Lib;

public class SendCommand : ICommand
{
    ICommand cmd;
    ICommandReceiver receiver;
    public SendCommand(ICommand cmd, ICommandReceiver receiver)
    {
        this.cmd = cmd;
        this.receiver = receiver;
    }
    public void Execute()
    {
        receiver.Receive(cmd);
    }
}