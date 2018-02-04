using System;
using System.Diagnostics.Tracing;

namespace GBBCoffeeShop.Common
{

    [EventSource(Name = "GBBCoffeeShop")]
    public sealed class LoggingService : EventSource
    {
        public class Keywords
        {           
            public const EventKeywords Diagnostic = (EventKeywords)1;
            public const EventKeywords Database = (EventKeywords)2;
            public const EventKeywords ApiController = (EventKeywords)4;
        }

        public class Tasks
        {
            public const EventTask Common = (EventTask)1;            
            public const EventTask Database = (EventTask)2;            
            public const EventTask Exception = (EventTask)4;
        }

        [Event(1, Message = "Error: {0}", Level = EventLevel.Error, Keywords = Keywords.Diagnostic)]
        public void Error(string message) { this.WriteEvent(1, message); }
        

        [Event(4, Message = "Info: {0}", Opcode = EventOpcode.Info,
            Task = Tasks.Common, Keywords = Keywords.Diagnostic | Keywords.Diagnostic, Level = EventLevel.Informational)]
        public void Info(string message)
        {
            if (this.IsEnabled()) this.WriteEvent(4, message);
        }

        [Event(5, Level = EventLevel.Error, Message = "Error in Database: {0}", Keywords = Keywords.Database, Task = Tasks.Database)]
        public void DatabaseError(string message) { this.WriteEvent(5, message); }
        

        [NonEvent]
        public void Exception(string message, Exception ex) { this.Exception(message, ExceptionHelper.FormatException(ex, includeContext: true)); }

        [Event(19, Message = "Error: {0}", Level = EventLevel.Error, Keywords = Keywords.Diagnostic, Task = Tasks.Exception)]
        public void Exception(string message, string exception) { this.WriteEvent(19, message, exception); }

        private static readonly Lazy<LoggingService> Instance = new Lazy<LoggingService>(() => new LoggingService());

        private LoggingService()
        {
        }

        public static LoggingService Log
        {
            get
            {
                return Instance.Value;
            }
        }

    }
}
