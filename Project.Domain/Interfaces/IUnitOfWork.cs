namespace Project.Domain.Interfaces;
public interface IUnitOfWork
{
    Task CommitAsync();
}
