using Application.Event;
using Application.Event.Handler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dispatcher {
    public interface IEventDispatcher {
        void Dispatch<TEvent>(TEvent @event) where TEvent : IEvent;
    } //interface
}
