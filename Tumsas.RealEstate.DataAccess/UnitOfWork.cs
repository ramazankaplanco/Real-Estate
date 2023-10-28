using Tumsas.RealEstate.DataAccess.Abstract;
using Tumsas.RealEstate.DataAccess.EntityFrameworkCore;

namespace Tumsas.RealEstate.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private RealEstateDbContext _context;
        private bool _disposed;

        public IUserRepository UserRepository { get; set; }
        public ICategoryRepository CategoryRepository { get; set; }

        public UnitOfWork(RealEstateDbContext context,
            IUserRepository userRepository,
            ICategoryRepository categoryRepository)
        {
            _context = context;

            UserRepository = userRepository;
            CategoryRepository = categoryRepository;
        }

        public bool Save()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
                _context.Dispose();

            _disposed = true;
        }
    }
}