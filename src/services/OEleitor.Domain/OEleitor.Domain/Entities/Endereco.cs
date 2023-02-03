using OEleitor.Infra.CrossCurtting.DomainObjects;
using System;

namespace OEleitor.Domain.Entities
{
    public class Endereco : BaseEntity
    {
        public Guid EleitorId { get; private set; }
        public Eleitor Eleitor { get; private set; }
        public string Logradouro { get; private set; }
        public string? Numero { get; private set; }
        public string? Complemento { get; private set; }
        public Guid BairroId { get; private set; }
        public Bairro Bairro { get; private set; }
        public string? Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Endereco(string logradouro,
          string numero,
          string complemento,
          Guid bairroId,
          string cep,
          string cidade,
          string estado,
          Guid eleitorId) => (Logradouro, Numero, Complemento, BairroId, Cep,
                            Cidade, Estado, EleitorId)
                          = (logradouro, numero, complemento, bairroId, cep,
                            cidade, estado, eleitorId);
        protected Endereco() { }
    }
}
