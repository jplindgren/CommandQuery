using Application.Command;
using Application.Command.Handler;
using Application.Dispatcher;
using Application.Event.Handler;
using Application.FakeInfra;
using Application.Validators;
using CommandQueryTest.Dispatcher;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandQueryTest {
    public class CommandQueryUnityExtension : UnityContainerExtension{

        protected override void Initialize() {
            //Result
            //Container.RegisterType(typeof(ICommandResult<>), typeof(CloseEventCommandResult));

            //Dispatchers
            Container.RegisterType(typeof(ICommandDispatcher), typeof(CommandDispatcher));
            Container.RegisterType(typeof(IEventDispatcher), typeof(EventDispatcher));

            //Events
            //Container.RegisterType<IEventHandler<ClosedEvent>, LuceneSyncOnClosedEventHandler>("ClosedEventLuceneSync");
            //Container.RegisterType<IEventHandler<ClosedEvent>, NotifyOnClosedEventHandler>("ClosedEventNotify");

            //Validators
            Container.RegisterType<IValidator<CloseEventCommand>, CloseEventValidator>("CloseEventInputValidation");
            Container.RegisterType<IEnumerable<IValidator<CloseEventCommand>>, IValidator<CloseEventCommand>[]>();

            //Commands and Commands Chain
            //Container.RegisterType(typeof(ICommandHandler<CloseEventCommand, CloseEventCommandResult>), typeof(CloseEventCommandHandler));

            IDictionary<Type, Type> commandHandlerRegistrations = GetHandlersByType(typeof(ICommandHandler<,>));
            foreach (var key in commandHandlerRegistrations.Keys) {
                Container.RegisterType(commandHandlerRegistrations[key], key);
            }

            IDictionary<Type, Type> eventHandlerRegistrations = GetHandlersByType(typeof(IEventHandler<>));
            foreach (var key in eventHandlerRegistrations.Keys) {
                Container.RegisterType(eventHandlerRegistrations[key], key, key.Name);
            }
        }

        private IDictionary<Type, Type> GetHandlersByType(Type type) {
            var assemblies = new Assembly[] { typeof(Logger).Assembly };
            return (from assembly in assemblies
                    from implementation in assembly.GetExportedTypes()
                    where !implementation.IsAbstract
                    where !implementation.ContainsGenericParameters
                    let services =
                        from iface in implementation.GetInterfaces()
                        where iface.IsGenericType
                        where iface.GetGenericTypeDefinition() == type
                        select iface
                    from service in services
                    select new { service, implementation }).ToDictionary(item => item.implementation, item => item.service);
        }
    } //class
}
