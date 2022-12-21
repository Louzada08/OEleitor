namespace OEleitor.Domain.Entities
{
    public class Bairro : Entity
    {
        public string BairroNome { get; private set; }
        public Endereco Endereco { get; private set; }

        protected Bairro() { }
        public Bairro(string bairroNome)
        {
            BairroNome = bairroNome;
        }
    }
}