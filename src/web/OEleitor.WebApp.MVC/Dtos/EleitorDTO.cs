namespace OEleitor.WebApp.MVC.Dtos
{
    public class EleitorDTO
  {
        public Guid EleitorId { get; set; }
        public string Nome { get; set; }
        public string? Apelido { get; set; }
        public DateTime? Aniversario { get; set; }
        public SexoEleitorDTO Sexo { get; set; }
        public string? Email { get; set; }
        public Guid? BairroId { get; set; }
        public BairroDTO? Bairro { get; set; }
        public EnderecoDTO EnderecoDTO { get; set; }
        public FoneEleitorDTO Fone { get; set; }
        public string? Observacao { get; set; }
        public IEnumerable<DependenteDTO> Dependentes { get; set; }
  }
}
