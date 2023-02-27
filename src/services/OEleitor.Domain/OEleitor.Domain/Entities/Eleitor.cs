using OEleitor.Infra.CrossCurtting.DomainObjects;
using OEleitor.Infra.CrossCurtting.DomainObjects.Interfaces;
using System;
using System.Collections.Generic;

namespace OEleitor.Domain.Entities
{
    public class Eleitor : BaseEntity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string? Apelido { get; private set; }
        public DateTime? Aniversario { get; private set; }
        public SexoEleitor Sexo { get; protected set; }
        public string? Email { get; private set; }
        public Guid? BairroId { get; private set; }
        public Bairro? Bairro { get; private set; }
        public Endereco Endereco { get; protected set; }
        public FoneEleitor Fone { get; protected set; }
        public string? Observacao { get; private set; }
        public ICollection<Dependente> Dependentes { get; private set; }

        protected Eleitor()
        {
            Dependentes = new List<Dependente>();
        }

        public Eleitor(string nome, string apelido, DateTime aniversario, string email,
                       string observacao, string fone1, bool fone1TemWp, string fone2,
                       bool fone2TemWp, SexoEleitor sexo, Guid bairroId, 
                       string logradouro, string numero, string complemento, string cep, string cidade, string estado)
        {
            Nome = nome;
            Apelido = apelido;
            Aniversario = aniversario;
            Email = email;
            Observacao = observacao;
            Fone = new FoneEleitor(fone1, fone1TemWp, fone2, fone2TemWp);
            Sexo = sexo;
            BairroId = bairroId;
            Endereco = new Endereco(logradouro, numero, complemento, cep, cidade, estado);
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
    }
}
