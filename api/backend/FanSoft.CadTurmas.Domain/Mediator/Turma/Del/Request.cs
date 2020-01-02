using System;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Turma.Del
{
    public class Request : IRequest<Response>
    {
        public Guid Id { get; set; }
    }
}