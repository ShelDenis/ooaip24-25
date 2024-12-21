using Xunit;
using Moq;
namespace SpaceBattle.Lib.Tests;

public class EmptyCommandTest
{
    [Fact]
    public void Execute_EmptyCommand()
    {
        var emptyCommand = new EmptyCommand();
        var exception = Record.Exception(() => emptyCommand.Execute());
        Assert.Null(exception);
    }
}