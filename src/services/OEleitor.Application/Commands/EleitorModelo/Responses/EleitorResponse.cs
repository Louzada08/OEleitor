using OEleitor.Domain.Dtos;
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
    public EnderecoDto EnderecoDto { get; set; }
    public Guid? BairroId { get; set; }
    public BairroDto? BairroDto { get; set; }
    public FoneEleitorDto FoneDto { get; set; }
    public string? Observacao { get; set; }
    public List<DependenteDto> DependentesDto { get; set; }
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
