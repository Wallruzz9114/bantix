using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Libraries.Abstraction.Notifications;
using MediatR;

namespace Libraries.Abstraction.Handlers
{
    public class EntityNotificationHandler : INotificationHandler<EntityNotification>
    {
        private List<EntityNotification> _notifications;

        public EntityNotificationHandler()
        {
            _notifications = new List<EntityNotification>();
        }

        public virtual List<EntityNotification> GetNotifications()
        {
            return _notifications;
        }

        public Task Handle(EntityNotification message, CancellationToken cancellationToken)
        {
            _notifications.Add(message);
            return Task.CompletedTask;
        }

        public virtual bool HasNotifications()
        {
            return _notifications.Any();
        }

        public virtual void ClearNotifications()
        {
            _notifications.Clear();
        }

        public void Dispose()
        {
            _notifications = new List<EntityNotification>();
        }
    }
}