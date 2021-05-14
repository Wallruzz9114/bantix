using System;
using Libraries.Abstraction.Events;

namespace Libraries.Abstraction.Commands
{
    public abstract class Command : Message
    {
        protected DateTime Timestamp { get; private set; }

        public Command()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}