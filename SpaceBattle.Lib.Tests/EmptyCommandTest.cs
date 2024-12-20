using Moq;
using Xunit;
namespace SpaceBattle.Lib.Tests;

public class EmptyCommandTest
{
    [Fact]
    public void Execute_EmptyCommand()
    {
        var empty_cmd = new Mock<ICommand>();
        empty_cmd.Object.Execute();

        empty_cmd.Verify(x => x.Execute());
    }
}
