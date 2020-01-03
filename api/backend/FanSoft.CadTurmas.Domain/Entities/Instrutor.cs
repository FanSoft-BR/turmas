using System;

namespace FanSoft.CadTurmas.Domain.Entities
{
    public class Instrutor : Entity
    {
        public Instrutor(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Instrutor(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        protected Instrutor() {}
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        internal void Update(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}