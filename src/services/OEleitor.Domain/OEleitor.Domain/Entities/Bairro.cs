namespace OEleitor.Domain.Entities
{
    public class Bairro : Entity
    {
        public string BairroNome { get; private set; }
        public long EnderecoId { get; private set; }

        protected Bairro() { }
        public Bairro(string bairroNome, long enderecoId)
        {
            BairroNome = bairroNome;
            EnderecoId = enderecoId;
        }
    }
}