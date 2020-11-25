using System.Threading.Tasks;
using JobInterviewTask.Domain.Repositories;
using JobInterviewTask.Persistence.Context;

namespace JobInterviewTask.Persistence.Repositiories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
