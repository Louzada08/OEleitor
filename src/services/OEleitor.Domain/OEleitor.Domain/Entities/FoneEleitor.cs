namespace OEleitor.Domain.Entities
{
    public class FoneEleitor
    {
        public FoneEleitor() { }
        public FoneEleitor(string fone1, bool fone1TemWp, string fone2, bool fone2TempWp)
        {
            Fone1 = fone1;
            Fone2 = fone2;
            Fone1TemWhatsapp = fone1TemWp;
            Fone2TemWhatsapp = fone2TempWp;
        }

        public string? Fone1 { get; set; }
        public bool? Fone1TemWhatsapp { get; set; }
        public string? Fone2 { get; set; }
        public bool? Fone2TemWhatsapp { get; set; }
    }
}
