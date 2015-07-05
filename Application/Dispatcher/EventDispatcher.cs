using Application.Event;
using Application.Event.Handler;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dispatcher {
    public class EventDispatcher : IEventDispatcher{
        private readonly IUnityContainer container;

        public EventDispatcher(IUnityContainer container) {
            if (container == null) throw new ArgumentNullException("container");
            this.container = container;
        }

        public void Dispatch<TEvent>(TEvent @event) where TEvent : Event.IEvent {
            if (@event == null) throw new ArgumentNullException("event");

            var handlers = container.ResolveAll<IEventHandler<TEvent>>().ToList();
            handlers.ForEach(x => x.Handle(@event));
        }
    } //class
}
