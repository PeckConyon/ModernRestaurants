using JobSchedule.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSchedule.Context.Repositories.BaseRepository.JobTemplateRepo
{
    public interface IJobTemplateRepository : IRepository<JobTemplate>
    {

        Task<JobTemplate> GetWithCategoryAsync(int id);

        Task<IEnumerable<JobTemplate>> GetAllWithCategoryAsync();

        Task<IEnumerable<JobTemplate>> GetAllCompletedJobsAsync();
    }
}
