namespace FinalProject.Interfaces
{
    public interface IUnitOfWork
    {
        int Commit();
        Task<int> CommitAsync();
    }
}
