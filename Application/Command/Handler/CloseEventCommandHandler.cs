using Application.Command.Result;
using Application.Dispatcher;
using Application.Event;
using Application.Validators;
using Domain;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Handler {
    public class CloseEventCommandHandler : ICommandHandler<CloseEventCommand, CloseEventCommandResult>{
        private IEventDispatcher _eventDispatcher;
        private IEnumerable<IValidator<CloseEventCommand>> _validators;

        public CloseEventCommandHandler(IEventDispatcher eventDispatcher, IEnumerable<IValidator<CloseEventCommand>> validators) {
            this._eventDispatcher = eventDispatcher;
            this._validators = validators;
        }

        private void Validate(CloseEventCommand command) {
            foreach (var validator in _validators) {
                validator.Validate(command);
            }           
        }

        public CloseEventCommandResult Handle(CloseEventCommand command) {
            Validate(command);

            var handledEvents = new List<Domain.Event>();
            foreach (var @event in command.Events) {
                @event.Progress = command.Progress;
                @event.EndDate = command.EndDate;
                @event.UpdatedAt = command.UpdateTime;
                @event.LastUpdateBy = command.Username;
                handledEvents.Add(@event);
            }

            _eventDispatcher.Dispatch(new ClosedEvent(command.CorrelationId) { Events = handledEvents });

            return new CloseEventCommandResult() {
                Events = handledEvents
            };
        }

    } //class
}
