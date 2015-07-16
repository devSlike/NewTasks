namespace Tasks.DataAccess.Infrastructure
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}