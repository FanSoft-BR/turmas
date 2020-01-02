using System;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Turma.Edit
{
    public class Request : IRequest<Response>
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        
    }
}