using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain{
    public class Event{
        public Guid? Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? EndDate { get; set; }
        public byte Progress { get; set; }
        public EventStatus Status { get; set; }
    } //class

    public enum EventStatus { 
        InProgress = 0,
        Closed = 1,
        Cancelled = 2
    }
}
