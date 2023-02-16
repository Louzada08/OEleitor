using System;
using System.Collections.Generic;

namespace OEleitor.Domain.Dtos
{
    public class EleitorDto
  {
        public Guid EleitorId { get; set; }
        public string Nome { get; set; }
        public string? Apelido { get; set; }
        public DateTime? Aniversario { get; set; }
        public SexoEleitorDto Sexo { get; set; }
        public string? Email { get; set; }
        public Guid? BairroId { get; set; }
        public BairroDto? Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Numero { get; set; }
        public string Fone1 { get; set; }
        public bool Fone1TemWhatsapp { get; set; }
        public string Fone2 { get; set; }
        public bool Fone2TemWhatsapp { get; set; }
        public string? Observacao { get; set; }
        public IEnumerable<DependenteDto> Dependentes { get; set; }
  }
}
