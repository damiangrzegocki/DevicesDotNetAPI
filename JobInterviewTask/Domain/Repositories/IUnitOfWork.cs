using System.Threading.Tasks;

namespace JobInterviewTask.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
