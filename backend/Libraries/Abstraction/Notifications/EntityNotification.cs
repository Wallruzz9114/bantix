using System;
using Libraries.Abstraction.Events;

namespace Libraries.Abstraction.Notifications
{
    public class EntityNotification : Event
    {
        public EntityNotification(string key, string value)
        {
            EntityNotificationId = Guid.NewGuid();
            Key = key;
            Value = value;
            Version = 1;
        }

        public Guid EntityNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public int Version { get; private set; }
    }
}