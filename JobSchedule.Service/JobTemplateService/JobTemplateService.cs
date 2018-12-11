using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobSchedule.Context.UnitOfWork;
using JobSchedule.Entities.Models;

namespace JobSchedule.Service.JobTemplateService
{
    public class JobTemplateService : IJobTemplateService
    {
        private readonly IUnitOfWork unitOfWork;

        public JobTemplateService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<JobTemplate> AddAsync(JobTemplate entity)
        {
            return await unitOfWork.JobTemplates.AddAsync(entity);
        }

        public async Task<IEnumerable<JobTemplate>> GetAllAsync()
        {
            return await unitOfWork.JobTemplates.GetAllAsync();
        }

        public async Task<JobTemplate> GetAsync(int id)
        {
            return await unitOfWork.JobTemplates.GetAsync(id);
        }

        public async Task<JobTemplate> RemoveAsync(JobTemplate entity)
        {
            return await unitOfWork.JobTemplates.RemoveAsync(entity);
        }

        public async Task<JobTemplate> UpdateAsync(JobTemplate entity)
        {
            return await unitOfWork.JobTemplates.UpdateAsync(entity);
        }

        public async Task<bool> IsExist(int id)
        {
            return await unitOfWork.JobTemplates.IsExist(id);
        }

        public async Task<IEnumerable<JobTemplate>> GetAllCompletedJobsAsync()
        {
           return await unitOfWork.JobTemplates.GetAllCompletedJobsAsync();
        }

        public async Task<JobTemplate> GetWithCategoryAsync(int id)
        {
            return await unitOfWork.JobTemplates.GetWithCategoryAsync(id);
        }

        public async Task<IEnumerable<JobTemplate>> GetAllWithCategoryAsync()
        {
            return await unitOfWork.JobTemplates.GetAllWithCategoryAsync();
        }
    }
}
