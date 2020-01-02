using System;
using MediatR;

namespace FanSoft.CadTurmas.Domain.Mediator.Turma.Add
{
    public class Notification : INotification
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataHora { get; set; } = DateTime.Now;

        public override string ToString()
            => $"Turma {Nome} inserida com sucesso em {DataHora}";
    }
}