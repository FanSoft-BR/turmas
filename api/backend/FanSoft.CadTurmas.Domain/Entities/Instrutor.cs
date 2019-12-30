namespace FanSoft.CadTurmas.Domain.Entities
{
    public class Instrutor : Entity
    {
        public Instrutor(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        protected Instrutor() {}
        public int Id { get; private set; }
        public string Nome { get; private set; }
    }
}