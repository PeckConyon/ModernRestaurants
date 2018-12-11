using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobSchedule.Context.UnitOfWork;
using JobSchedule.Entities.Models;

namespace JobSchedule.Service.JobService
{
    public class JobService : IJobService
    {
        private readonly IUnitOfWork unitOfWork;

        public JobService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<Job> AddAsync(Job entity)
        {
            return await unitOfWork.Jobs.AddAsync(entity);
        }

        public async Task<IEnumerable<Job>> GetAllAsync()
        {
            return await unitOfWork.Jobs.GetAllAsync();
        }

        public async Task<Job> GetAsync(int id)
        {
            return await unitOfWork.Jobs.GetAsync(id);
        }

        public async Task<Job> RemoveAsync(Job entity)
        {
            return await unitOfWork.Jobs.RemoveAsync(entity);
        }

        public async Task<Job> UpdateAsync(Job entity)
        {
            return await unitOfWork.Jobs.UpdateAsync(entity);
        }

        public async Task<bool> IsExist(int id)
        {
            return await unitOfWork.Jobs.IsExist(id);
        }

        public async Task<Job> GetWithCategoryAsync(int id)
        {
            return await unitOfWork.Jobs.GetWithCategoryAsync(id);
        }

        public async Task<IEnumerable<Job>> GetAllWithCategoryAsync()
        {
            return await unitOfWork.Jobs.GetAllWithCategoryAsync();
        }

        public async Task<IEnumerable<Job>> GetAllPendingJobsAsync()
        {
            return await unitOfWork.Jobs.GetAllPendingJobsAsync();
        }
    }
}
