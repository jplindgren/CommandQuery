using Application.Command;
using Application.Command.Result;
using CommandQueryTest.Dispatcher;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CommandQueryTest.Controllers {
    public class ValuesController : ApiController {
        private ICommandDispatcher commandDispatcher;
        public ValuesController(ICommandDispatcher commandDispatcher) {
            this.commandDispatcher = commandDispatcher;
        }

        // GET api/values
        public IEnumerable<string> Get() {
            var closeEventCommand = new CloseEventCommand() {
                Events = FakeEvents(),
                Comment = "Fechando por teste",
                EndDate = DateTime.Now.AddDays(-1),
                Progress = 100,
                UpdateTime = DateTime.Now,
                Username = "joao.lindgren"
            };
            this.commandDispatcher.Dispatch<CloseEventCommand, CloseEventCommandResult>(closeEventCommand);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id) {
            return "value";
        }

        // POST api/values
        public void Post() {
            var closeEventCommand = new CloseEventCommand(){
                Events = FakeEvents(),
                Comment = "Fechando por teste",
                EndDate = DateTime.Now.AddDays(-1),
                Progress = 100,
                UpdateTime = DateTime.Now,
                Username = "joao.lindgren"
            };
            this.commandDispatcher.Dispatch<CloseEventCommand, CloseEventCommandResult>(closeEventCommand);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/values/5
        public void Delete(int id) {
        }

        private List<Event> FakeEvents() {
            return new List<Event>() { 
                new Event(){
                    Code = "EVT000001",
                    CreatedAt = DateTime.Now.AddDays(-15),
                    Id = Guid.NewGuid(),
                    LastUpdateBy = "Administrator",
                    Progress = 10,
                    Status = EventStatus.InProgress,
                    Title = "Event 1",
                    UpdatedAt = DateTime.Now.AddDays(-10)
                },
                new Event(){
                    Code = "EVT000002",
                    CreatedAt = DateTime.Now.AddDays(-34),
                    Id = Guid.NewGuid(),
                    LastUpdateBy = "joao.lindgren",
                    Progress = 0,
                    Status = EventStatus.InProgress,
                    Title = "Event 2",
                    UpdatedAt = DateTime.Now.AddDays(-11)
                }
            };
        }
    } //class
}