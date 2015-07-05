using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command {
    public interface ICommand {
        Guid CorrelationId { get; }
    }
}
