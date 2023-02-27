using OEleitor.Domain.Entities;
using System;

namespace OEleitor.Domain.Dtos
{
    public class DependenteDto
    {
        public Guid Id { get; set; }
        public Guid EleitorId { get; set; }
        public string Nome { get; set; }
        public TipoDependente Tipo { get; set; }
        public DateTime? Nascimento { get; set; }
        public string? Fone { get; set; }
    }
}
