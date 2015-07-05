using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Event.Handler {
    public interface IMessageSender {
        void Publish(string message);
    }
}
