﻿namespace OEleitor.Domain.Entities
{
    public class Endereco : Entity
    {
        public long EleitorId { get; private set; }
        public Eleitor Eleitor { get; private set; }
        public string Logradouro { get; private set; }
        public string? Numero { get; private set; }
        public string? Complemento { get; private set; }
        public long BairroId { get; private set; }
        public Bairro Bairro { get; private set; }
        public string? Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Endereco(string logradouro,
          string numero,
          string complemento,
          long bairroId,
          string cep,
          string cidade,
          string estado,
          long eleitorId) => (Logradouro, Numero, Complemento, BairroId, Cep,
                            Cidade, Estado, EleitorId)
                          = (logradouro, numero, complemento, bairroId, cep,
                            cidade, estado, eleitorId);
        protected Endereco() { }
    }
}
