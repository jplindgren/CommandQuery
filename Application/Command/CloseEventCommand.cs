using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Command {
    public class CloseEventCommand : ICommand{
        public CloseEventCommand() {
            CorrelationId = Guid.NewGuid();
        }
        public List<Domain.Event> Events { get; set; }
        public string Comment { get; set; }
        public DateTime? EndDate { get; set; }
        public byte Progress { get; set; }
        public string Username { get; set; }
        public DateTime UpdateTime { get; set; }

        public Guid CorrelationId { get; private set; }
    } //class
}
