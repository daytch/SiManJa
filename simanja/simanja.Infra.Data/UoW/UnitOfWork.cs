using uangsaku.Domain.Interfaces;
using uangsaku.Infra.Data.Context;

namespace uangsaku.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UangsakuContext _context;

        public UnitOfWork(UangsakuContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
