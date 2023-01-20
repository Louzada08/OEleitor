using OEleitor.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OEleitor.Application.Commands.EleitorModelo.Responses;

public class AdicionarEleitorResponse 
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
