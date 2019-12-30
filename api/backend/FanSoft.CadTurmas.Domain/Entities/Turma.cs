using System;

namespace FanSoft.CadTurmas.Domain.Entities
{
    public class Turma : Entity
    {
        protected Turma() {}

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
    }
}