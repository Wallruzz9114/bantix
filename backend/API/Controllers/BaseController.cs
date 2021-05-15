using System;
using System.Linq;
using Core.Services.Interfaces;
using Libraries.Abstraction.Handlers;
using Libraries.Abstraction.Interfaces;
using Libraries.Abstraction.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected readonly EntityNotificationHandler _notificationHandler;
        private readonly IMediatorHandler _mediator;
        protected Guid UserId { get; set; }

        public BaseController(INotificationHandler<EntityNotification> notificationHandler, IUserService userService, IMediatorHandler mediator)
        {
            _notificationHandler = (EntityNotificationHandler)notificationHandler;
            _mediator = mediator;

            if (userService.IsAuthenticated())
            {
                UserId = userService.GetAuthId();
            }
            else
            {
                UserId = Guid.Empty;
            }
        }

        protected new IActionResult Response(object result = null)
        {
            if (!ModelState.IsValid) HandleInvalidModel();
            if (OperationIsValid()) return Ok(result);

            return BadRequest(new
            {
                errors = _notificationHandler.GetNotifications().Select(p => p.Value)
            });
        }

        protected bool OperationIsValid() => !_notificationHandler.HasNotifications();

        protected void HandleInvalidModel()
        {
            var errors = ModelState.Values.SelectMany(e => e.Errors);

            foreach (var error in errors)
            {
                var errorMessage = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                HandleError(string.Empty, errorMessage);
            }
        }

        protected void HandleError(string code, string message)
        {
            _mediator.RaiseEvent(new EntityNotification(code, message));
        }
    }
}