using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command.Result {
    public class CloseEventCommandResult {
        public List<Domain.Event> Events { get; set; }
    } //class
}
