using OEleitor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OEleitor.Application.Commands.EleitorModelo.Responses;

public class EleitorResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string? Apelido { get; set; }
    public DateTime? Aniversario { get; set; }
    public SexoEleitor Sexo { get; set; }
    public string? Email { get; set; }
    public Endereco Endereco { get; set; }
    public FoneEleitor Fone { get; set; }
    public ICollection<Dependente> Dependentes { get; set; }
    public string? Observacao { get; set; }
}

public enum SexoEleitor
{
    Masculino = 1,
    Feminino
}

public class FoneEleitor
{
    public string? Fone1 { get; set; }
    public bool? Fone1TemWhatsapp { get; set; }
    public string? Fone2 { get; set; }
    public bool? Fone2TemWhatsapp { get; set; }
}
