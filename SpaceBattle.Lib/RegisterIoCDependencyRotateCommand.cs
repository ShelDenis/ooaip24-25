﻿using App;
namespace SpaceBattle.Lib;

public class RegisterIoCDependencyRotateCommand : ICommand
{
    public void Execute()
    {
        Ioc.Resolve<App.ICommand>(
            "IoC.Register",
            "Commands.Rotate",
            (object[] args) => new RotateCommand(Ioc.Resolve<IRotate>("Adapters.IRotateObject", args))
        ).Execute();
    }
}
