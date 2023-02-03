namespace OEleitor.WebApp.MVC.Models
{
    public class EnderecoViewModel
    {
        public Guid Id { get; set; }
        public Guid EleitorId { get; set; }
        public string Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public Guid BairroId { get; set; }
        public BairroViewModel Bairro { get; set; }
        public string? Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
