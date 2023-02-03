using OEleitor.Infra.CrossCurtting.Messages;
using System;

namespace OEleitor.Application.Commands.EnderecoModelo.Requests;

public class EnderecoCommand : Command
{
    public Guid EleitorId { get; set; }
    public string Logradouro { get; set; }
    public string? Numero { get; set; }
    public string? Complemento { get; set; }
    public Guid BairroId { get; set; }
    public BairroCommand Bairro { get; set; }
    public string? Cep { get; set; }
    public string Cidade { get; set; }
    public string Estado { get; set; }
}
