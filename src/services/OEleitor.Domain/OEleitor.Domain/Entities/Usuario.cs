using OEleitor.Infra.CrossCurtting.Identidade;
using System.Collections.Generic;

namespace OEleitor.Domain.Entities
{
    public class Usuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        public ICollection<Funcao> Funcoes { get; set; }

        public Usuario()
        {
            Funcoes = new HashSet<Funcao>();
        }
    }

    public enum StatusConta
    {
        Analisando, Aprovado, Reprovado
    }
}
