using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Handler {
    public interface ICommandHandler<in TCommand, out TResult> where TCommand : ICommand {
        TResult Handle(TCommand command);
    } //interface
}
