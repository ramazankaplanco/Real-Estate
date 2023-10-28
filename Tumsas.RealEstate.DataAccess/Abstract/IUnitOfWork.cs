namespace Tumsas.RealEstate.DataAccess.Abstract
{
    public interface IUnitOfWork : IDisposable
    {
        bool Save();

        IUserRepository UserRepository { get; }
        ICategoryRepository CategoryRepository { get; set; }
    }
}