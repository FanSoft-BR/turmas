using System;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Turma.Add
{
    public class Request : IRequest<Response>
    {
        
        public string Nome { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public int? InstrutorId { get; set; }
        public string Descricao { get; set; }
        
    }
}