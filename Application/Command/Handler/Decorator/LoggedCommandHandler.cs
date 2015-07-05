using Application.FakeInfra;
using Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Handler.Decorator {
    public class LoggedCommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult> where TCommand : ICommand {
        private ICommandHandler<TCommand, TResult> innerCommandHandler;
        private ILogger logger;

        public LoggedCommandHandler(ICommandHandler<TCommand, TResult> innerCommandHandler, ILogger logger) {
            this.innerCommandHandler = innerCommandHandler;
            this.logger = logger;
        }

        public TResult Handle(TCommand command) {
            logger.Log("command fired");
            return innerCommandHandler.Handle(command);
        }
    } //class
}
