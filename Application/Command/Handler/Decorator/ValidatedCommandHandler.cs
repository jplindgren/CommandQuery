using Application.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Handler.Decorator {
    public class ValidatedCommandHandler<TCommand, TResult> : ICommandHandler<TCommand, TResult> where TCommand : ICommand {
        private ICommandHandler<TCommand, TResult> innerCommandHandler;
        private IEnumerable<IValidator<TCommand>> validators;

        public ValidatedCommandHandler(ICommandHandler<TCommand, TResult> innerCommandHandler, IEnumerable<IValidator<TCommand>> validators) {
            this.innerCommandHandler = innerCommandHandler;
            this.validators = validators;
        }

        public TResult Handle(TCommand command) {
            foreach (var validator in validators) {
                validator.Validate(command);
            }
            return innerCommandHandler.Handle(command);
        }
    } //class
}
