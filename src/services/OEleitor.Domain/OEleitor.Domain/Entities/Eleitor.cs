using System;
using System.Collections.Generic;

namespace OEleitor.Domain.Entities
{
    public class Eleitor : Entity
    {
        public string Nome { get; private set; }
        public string? Apelido { get; private set; }
        public DateTime? Aniversario { get; private set; }
        public SexoEleitor Sexo { get; private set; }
        public string? Email { get; private set; }
        public Endereco Endereco { get; private set; }
        public FoneEleitor Fone { get; private set; }
        public ICollection<Dependente> Dependentes { get; set; }
        public string? Observacao { get; private set; }

        protected Eleitor() { }
        public Eleitor(string nome, string apelido, DateTime aniversario, string email, string observacao)
        {
            Nome = nome;
            Apelido = apelido;
            Aniversario = aniversario;
            Email = email;
            Observacao = observacao;
        }

        public void AtribuirEndereco(Endereco endereco)
        {
            Endereco = endereco;
        }

        public void AtribuirFone(FoneEleitor foneEleitor)
        {
            Fone = foneEleitor;
        }

        public void AtribuirSexo(SexoEleitor sexoEleitor)
        {
            Sexo = sexoEleitor;
        }

        public enum SexoEleitor
        {
            Masculino = 1,
            Feminino
        }
        
        public class FoneEleitor
        {
            public string? Fone1 { get; private set; }
            public bool? Fone1TemWhatsapp { get; private set; }
            public string? Fone2 { get; private set; }
            public bool? Fone2TemWhatsapp { get; private set; }
        }
    }
}
