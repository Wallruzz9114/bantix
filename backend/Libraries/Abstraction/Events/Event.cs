using System;
using MediatR;

namespace Libraries.Abstraction.Events
{
    public class Event : Message, INotification
    {
        protected DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.UtcNow;
        }
    }
}