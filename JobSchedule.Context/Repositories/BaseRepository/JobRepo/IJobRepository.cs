using JobSchedule.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSchedule.Context.Repositories.BaseRepository.JobRepo
{
    public interface IJobRepository : IRepository<Job>
    {
        Task<Job> GetWithCategoryAsync(int id);

        Task<IEnumerable<Job>> GetAllWithCategoryAsync();

        Task<IEnumerable<Job>> GetAllPendingJobsAsync();
    }
}
