using System;

namespace FanSoft.CadTurmas.Domain.Entities
{
    public class Turma : Entity
    {

        public Turma(Guid id, string nome, string descricao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }
        public Turma(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        protected Turma() {}

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public void Update(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}