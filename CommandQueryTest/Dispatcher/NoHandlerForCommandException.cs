using Application.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandQueryTest.Dispatcher {
    public class NoHandlerForCommandException : Exception {
        public Type CommandType { get; private set; }
        public NoHandlerForCommandException(Type commandType) : base("No handler was found for the command provided"){
            this.CommandType = commandType;
        }
    } //class
}
