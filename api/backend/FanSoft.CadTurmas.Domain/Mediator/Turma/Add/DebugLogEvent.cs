using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Turma.Add
{
    public class DebugLogEvent : INotificationHandler<Notification>
    {
        public async Task Handle(Notification notification, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                Debug.WriteLine(notification.ToString());
            });
        }

    }
}
