namespace OEleitor.Infra.CrossCurtting.DomainObjects.Interfaces
{
    public interface IBaseEntity
    {
        Guid Id { get; set; }
        DateTime? DataCadastro { get; set; }
        DateTime? DataAlteracao { get; set; }
        DateTime? DataExclusao { get; set; }
    }
}
