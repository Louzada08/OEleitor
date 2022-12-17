using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OEleitor.Domain.Entities
{
    public class Dependente : Entity
    {
        public long EleitorId { get; private set; }
        public string Nome { get; private set; }
        public TipoDependente Tipo { get; private set; }
        public DateTime? Nascimento { get; private set; }
        public string? Fone { get; private set; }

        protected Dependente() { }

        public Dependente(string nome, DateTime nascimento, string fone, long eleitorId )
        {
            Nome = nome;
            Nascimento = nascimento;
            Fone = fone;
            EleitorId = eleitorId;
        }
    }

    public enum TipoDependente
    {
        Conjuge = 1,
        Filho = 2,
        Filha = 3,
        Pai = 4,
        Mae = 5,
        Outros
    }
}
