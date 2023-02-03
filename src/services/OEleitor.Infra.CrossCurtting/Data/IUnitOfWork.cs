namespace OEleitor.Infra.CrossCurtting.Data
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
        bool DatabaseExists();
    }
}
