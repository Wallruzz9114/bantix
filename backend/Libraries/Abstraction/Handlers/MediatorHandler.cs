using System.Threading;
using System.Threading.Tasks;
using Libraries.Abstraction.Commands;
using Libraries.Abstraction.Events;
using Libraries.Abstraction.Interfaces;
using MediatR;

namespace Libraries.Abstraction.Handlers
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T appEvent, CancellationToken cancellationToken = default) where T : Event
        {
            return _mediator.Publish(appEvent, cancellationToken);
        }

        public Task SendCommand<T>(T command, CancellationToken cancellationToken = default) where T : Command
        {
            return _mediator.Send(command, cancellationToken);
        }
    }
}