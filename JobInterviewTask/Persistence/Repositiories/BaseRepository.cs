using JobInterviewTask.Persistence.Context;

namespace JobInterviewTask.Persistence.Repositiories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;

        public BaseRepository(AppDbContext context)
        {
            _context = context;
        }
    }
}
