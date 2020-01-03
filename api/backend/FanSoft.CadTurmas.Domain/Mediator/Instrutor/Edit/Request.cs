using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Instrutor.Edit
{
 public class Request : IRequest<Response>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        
    }
}