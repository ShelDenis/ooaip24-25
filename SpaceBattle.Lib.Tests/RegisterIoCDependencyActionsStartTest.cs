﻿using App;
using App.Scopes;
using Moq;
using Xunit;
namespace SpaceBattle.Lib;

public class RegisterIoCDependencyActionsStartTest
{
    public RegisterIoCDependencyActionsStartTest()
    {
        new InitCommand().Execute();
        var iocScope = Ioc.Resolve<object>("IoC.Scope.Create");
        Ioc.Resolve<App.ICommand>("IoC.Scope.Current.Set", iocScope).Execute();
    }

    [Fact]
    public void CorrectResolveTest()
    {
        var obj = new Mock<IDictionary<string, object>>();

        var registerIoCDependencyActionsStart = new RegisterIoCDependencyActionsStart();
        registerIoCDependencyActionsStart.Execute();
        var res = Ioc.Resolve<ICommand>("Actions.Start", obj.Object);

        Assert.IsType<StartCommand>(res);
    }
}
