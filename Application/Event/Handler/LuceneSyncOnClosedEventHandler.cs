using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Event.Handler {
    public class LuceneSyncOnClosedEventHandler : IEventHandler<ClosedEvent>{
        private readonly IMessageSender _sender;

        public LuceneSyncOnClosedEventHandler(IMessageSender sender){
            _sender = sender;
        }

        public void Handle(ClosedEvent input) { 
            _sender.Publish(input.ToString());
        }
    } //class
}
