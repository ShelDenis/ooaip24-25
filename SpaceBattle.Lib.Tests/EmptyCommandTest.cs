using Moq;
using Xunit;
namespace SpaceBattle.Lib.Tests;

public class EmptyCommandTest
{
    [Fact]
    public void Execute_EmptyCommand()
    {
        var emptyCommand = new Mock<ICommand>();
        emptyCommand.Object.Execute();

        emptyCommand.Verify(x => x.Execute());
    }
}
