using Application.Command;
using Application.Command.Handler;
using Application.Command.Handler.Decorator;
using Application.FakeInfra;
using Application.Validators;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CommandQueryTest.Dispatcher {
    public class CommandDispatcher : ICommandDispatcher {
        private readonly IUnityContainer container;

        public CommandDispatcher(IUnityContainer container) {
            if (container == null) throw new ArgumentNullException("container");
            this.container = container;
        }

        public void Dispatch<TCommand, TResult>(TCommand command) where TCommand : ICommand {
            if (command == null) throw new ArgumentNullException("command");

            var handler = container.Resolve<ICommandHandler<TCommand, TResult>>();
            ThrowErrorIfNoHandlerForCommandFound(handler);

            var validators = container.ResolveAll<IValidator<TCommand>>();
            
            var validatedHandler = new ValidatedCommandHandler<TCommand, TResult>(handler, validators);
            var monitoredHandler = new LoggedCommandHandler<TCommand, TResult>(validatedHandler, container.Resolve<ILogger>());

            validatedHandler.Handle(command);
        }

        private static void ThrowErrorIfNoHandlerForCommandFound<TCommand, TResult>(ICommandHandler<TCommand, TResult> handler) where TCommand : ICommand {
            if (handler == null)
                throw new NoHandlerForCommandException(typeof(TCommand));
        }
    } //class
}