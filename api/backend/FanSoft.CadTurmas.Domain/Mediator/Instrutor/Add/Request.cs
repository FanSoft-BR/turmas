using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Instrutor.Add
{
    public class Request : IRequest<Response>
    {
        
        public string Nome { get; set; }
        public string Descricao { get; set; }
        
    }
}