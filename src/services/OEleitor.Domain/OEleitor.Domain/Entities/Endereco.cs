namespace OEleitor.Domain.Entities
{
    public class Endereco : Entity
    {
        public string Logradouro { get; }
        public string? Numero { get; }
        public string? Complemento { get; }
        public Bairro Bairro { get; }
        public string? Cep { get; }
        public string Cidade { get; }
        public string Estado { get; }
        public long ClienteId { get; }

        public Endereco(string logradouro,
          string numero,
          string complemento,
          string bairro,
          string cep,
          string cidade,
          string estado,
          long clienteId) => (Logradouro, Numero, Complemento, Cep,
                            Cidade, Estado, ClienteId)
                          = (logradouro, numero, complemento, cep,
                            cidade, estado, clienteId);
        protected Endereco() { }
    }
}
