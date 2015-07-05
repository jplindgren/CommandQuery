using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Event.Handler {
    public class NotifyOnClosedEventHandler : IEventHandler<ClosedEvent>{
        public void Handle(ClosedEvent @event) {
            Console.WriteLine("Sending fake email...");
        }
    } //class
}
