using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OEleitor.Domain.Entities
{
    public class Usuario : IdentityUser
    {
        public string CPF { get; set; }
        public string? Foto { get; set; }

        public bool PrimeiroAcesso { get; set; }
        public StatusConta Status { get; set; }
        protected Usuario() { }
    }

    public enum StatusConta
    {
        Analisando, Aprovado, Reprovado
    }
}
