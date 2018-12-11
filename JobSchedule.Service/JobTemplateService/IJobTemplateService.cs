using JobSchedule.Entities.Models;
using JobSchedule.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule.Service.JobTemplateService
{
    public interface IJobTemplateService : IService<JobTemplate>
    {
        Task<JobTemplate> GetWithCategoryAsync(int id);

        Task<IEnumerable<JobTemplate>> GetAllWithCategoryAsync();

        Task<IEnumerable<JobTemplate>> GetAllCompletedJobsAsync();
    }
}
