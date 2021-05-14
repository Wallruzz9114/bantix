using System.Threading.Tasks;
using FluentValidation.Results;
using Libraries.Abstraction.Interfaces;
using Libraries.Abstraction.Notifications;
using MediatR;

namespace Libraries.Abstraction.Handlers
{
    public abstract class CommandHandler
    {
        protected readonly IMediatorHandler _mediatorHandler;
        protected readonly EntityNotificationHandler _notificationHandler;

        public CommandHandler(IMediatorHandler mediatorHandler, INotificationHandler<EntityNotification> notificationHandler)
        {
            _mediatorHandler = mediatorHandler;
            _notificationHandler = (EntityNotificationHandler)notificationHandler;
        }

        protected void HandleValidationError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                _mediatorHandler
                    .RaiseEvent(new EntityNotification(error.PropertyName, error.ErrorMessage));
            }
        }

        protected void HandleError(string nome, string message)
        {
            _mediatorHandler.RaiseEvent(new EntityNotification(nome, message));
        }

        protected bool HasNotifications()
        {
            return _notificationHandler.HasNotifications();
        }

        protected static Task<bool> Sucess() => Task.FromResult(true);

        protected static Task<bool> Failure() => Task.FromResult(false);
    }
}