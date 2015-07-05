using Application.Event.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Event {
    public class ClosedEvent : IEvent{
        public ClosedEvent(Guid correlationId) {
            CorrelationId = correlationId;
        }
        public List<Domain.Event> Events { get; set; }
        public Guid CorrelationId { get; private set; }
    } //class
}
