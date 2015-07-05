using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Event.Handler {
    public interface IEventHandler<TEvent> where TEvent : IEvent {
        void Handle(TEvent @event);
    }//interface
}
