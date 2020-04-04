using System.Threading.Tasks;
using uangsaku.Domain.Core.Commands;
using uangsaku.Domain.Core.Events;


namespace uangsaku.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
