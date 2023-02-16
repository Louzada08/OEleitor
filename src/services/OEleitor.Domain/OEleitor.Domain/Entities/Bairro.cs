using OEleitor.Infra.CrossCurtting.DomainObjects;

namespace OEleitor.Domain.Entities
{
    public class Bairro : BaseEntity
    {
        public string BairroNome { get; private set; }
        protected Bairro() { }
        public Bairro(string bairroNome)
        {
            BairroNome = bairroNome;
        }
    }
}