﻿using System;

namespace OEleitor.Domain.Dtos
{
    public class EnderecoDto
    {
        public Guid EleitorId { get; set; }
        public string Logradouro { get; set; }
        public string? Numero { get; set; }
        public string? Complemento { get; set; }
        public Guid BairroId { get; set; }
        public string? Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
