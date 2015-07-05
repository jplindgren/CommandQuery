using Application.Command;
using Application.Command.Handler;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommandQueryTest.Dispatcher {
    public interface ICommandDispatcher {
        void Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand;
    }
}