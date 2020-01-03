using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Instrutor.Del
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
    }
}