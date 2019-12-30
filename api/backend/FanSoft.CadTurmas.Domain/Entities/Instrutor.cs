namespace FanSoft.CadTurmas.Domain.Entities
{
    public class Instrutor : Entity
    {
        protected Instrutor() {}
        public int Id { get; private set; }
        public string Nome { get; private set; }
    }
}