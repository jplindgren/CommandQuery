using Application.Command;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators {
    public interface IValidator<TCommand> where TCommand : ICommand {
        void Validate(TCommand command);
    } //class
}
