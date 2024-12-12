using Hwdtech;
namespace SpaceBattle.Lib;

public class RegisterIoCDependencyMoveCommand : ICommand
{
    public void Execute()
    {
        IoC.Resolve<ICommand>("IoC.Register",
                            "Commands.Move",
        (object[] args) => { return new MoveCommand(IoC.Resolve<IMoving>("Adapters.IMovingObject")); }).Execute();
    }
}