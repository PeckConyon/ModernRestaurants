using JobSchedule.Entities.Models;
using JobSchedule.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule.Service.JobService
{
    public interface IJobService : IService<Job>
    {
        Task<Job> GetWithCategoryAsync(int id);

        Task<IEnumerable<Job>> GetAllWithCategoryAsync();

        Task<IEnumerable<Job>> GetAllPendingJobsAsync();
    }
}
