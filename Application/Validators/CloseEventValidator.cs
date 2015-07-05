using Application.Command;
using FluentValidation;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators {
    public class CloseEventValidator : AbstractValidator<CloseEventCommand>, IValidator<CloseEventCommand> {
        public CloseEventValidator() {
            RuleFor(command => command.Username).NotEmpty();
            RuleFor(command => command.Events).Must(ValidateCollectionMinLengthPredicate);
            RuleFor(command => command.UpdateTime).Must(ValidateMinDateTimePredicate);
            //RuleFor(command => command.Progress).GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
            RuleFor(customer => customer.Comment).NotEmpty().WithMessage("Please specify a first name").Length(0, 256).WithMessage("With length less than 256");
        }

        public void Validate(CloseEventCommand command) {
            this.ValidateAndThrow(command);        
        }

        private bool ValidateCollectionMinLengthPredicate(List<Domain.Event> events) {
            return events.Count > 0;
        }

        private bool ValidateMinDateTimePredicate(DateTime datetime) {
            return datetime != DateTime.MinValue;
        }
    } //class
}
