namespace OEleitor.WebApp.MVC.Dtos
{
    public class DependenteDTO
    {
        public Guid EleitorId { get; set; }
        public EleitorDTO Eleitor { get; set; }
        public string Nome { get; set; }
        public TipoDependente Tipo { get; set; }
        public DateTime? Nascimento { get; set; }
        public string? Fone { get; set; }

    }

    public enum TipoDependente
    {
        Conjuge = 1,
        Filho = 2,
        Filha = 3,
        Pai = 4,
        Mae = 5,
        Outros
    }
}
