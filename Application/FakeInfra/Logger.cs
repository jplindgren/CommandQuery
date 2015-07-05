using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FakeInfra {
    public class Logger : Application.FakeInfra.ILogger {
        public void Log(string message) {
            System.Diagnostics.Trace.Write(message);
        } 
    } //class
}
