using System;
using System.Collections.Generic;

namespace FanSoft.CadTurmas.Domain.Entities
{
    public class Role : Entity
    {
        protected Role() { }
        public Role(int id, string nome, string descricao = null)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
        }

        public Role(string nome, string descricao = null)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }

        public IEnumerable<UsuarioRole> UsuarioRoles { get; private set; }

        public void Update(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }
    }
}