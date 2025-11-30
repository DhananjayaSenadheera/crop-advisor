namespace UserRegisterService.Domain.Interfaces;

public interface IUnitOfWork : IDisposable
{
    Task CommitAsync();
}