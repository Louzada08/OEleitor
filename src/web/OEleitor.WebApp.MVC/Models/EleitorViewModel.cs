namespace OEleitor.WebApp.MVC.Models
{
    public class EleitorViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string? Apelido { get; set; }
        public DateTime? Aniversario { get; set; }
        public SexoEleitor Sexo { get; set; }
        public string? Email { get; set; }
        public Guid EnderecoId { get; set; } 
        public EnderecoViewModel Endereco { get; set; }
        public FoneEleitor Fone { get; set; }
        public string? Observacao { get; set; }
    }
}
