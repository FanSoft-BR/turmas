using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Role.Del
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
    }
}
