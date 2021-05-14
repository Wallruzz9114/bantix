using System.Threading;
using System.Threading.Tasks;
using Libraries.Abstraction.Commands;
using Libraries.Abstraction.Events;

namespace Libraries.Abstraction.Interfaces
{
    public interface IMediatorHandler
    {
        Task RaiseEvent<T>(T appEvent, CancellationToken cancellation = default) where T : Event;
        Task SendCommand<T>(T command, CancellationToken cancellation = default) where T : Command;
    }
}