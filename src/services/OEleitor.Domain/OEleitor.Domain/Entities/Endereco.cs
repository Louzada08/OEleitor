namespace OEleitor.Domain.Entities;

public class Endereco
{
    public Endereco() { }
    public Endereco(string logradouro,
      string numero,
      string complemento,
      string cep,
      string cidade,
      string estado) => (Logradouro, Numero, Complemento, Cep, Cidade, Estado)
                      = (logradouro, numero, complemento, cep, cidade, estado);

    public string Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public string? Cep { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
}
