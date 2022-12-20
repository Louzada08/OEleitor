namespace OEleitor.Domain.Entities
{
    public class Endereco : Entity
    {
        public long EleitorId { get; }
        public Eleitor Eleitor { get; }
        public string Logradouro { get; }
        public string? Numero { get; }
        public string? Complemento { get; }
        public Bairro Bairro { get; }
        public string? Cep { get; }
        public string Cidade { get; }
        public string Estado { get; }

        public Endereco(string logradouro,
          string numero,
          string complemento,
          string bairro,
          string cep,
          string cidade,
          string estado,
          long eleitorId) => (Logradouro, Numero, Complemento, Cep,
                            Cidade, Estado, EleitorId)
                          = (logradouro, numero, complemento, cep,
                            cidade, estado, eleitorId);
        protected Endereco() { }
    }
}
