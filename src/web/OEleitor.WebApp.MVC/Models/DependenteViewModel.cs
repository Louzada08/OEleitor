namespace OEleitor.WebApp.MVC.Dtos
{
    public class DependenteViewModel
    {
        public Guid Id { get; set; }
        public Guid EleitorId { get; set; }
        public string NomeDependente { get; set; }
        public TipoDependente Tipo { get; set; }
        public DateTime? Nascimento { get; set; }
        public string? Fone { get; set; }

    }
}
