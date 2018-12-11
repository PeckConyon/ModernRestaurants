using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobSchedule.Context.UnitOfWork;
using JobSchedule.Entities.Models;

namespace JobSchedule.Service.JobCategoryService
{
    public class JobCategoryService : IJobCategoryService
    {
        private readonly IUnitOfWork unitOfWork;

        public JobCategoryService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        public async Task<JobCategory> AddAsync(JobCategory entity)
        {
            return await unitOfWork.JobCategories.AddAsync(entity);
        }

        public async Task<IEnumerable<JobCategory>> GetAllAsync()
        {
            return await unitOfWork.JobCategories.GetAllAsync();
        }

        public async Task<JobCategory> GetAsync(int id)
        {
            return await unitOfWork.JobCategories.GetAsync(id);

        }

        public async Task<JobCategory> RemoveAsync(JobCategory entity)
        {
            return await unitOfWork.JobCategories.RemoveAsync(entity);

        }

        public async Task<JobCategory> UpdateAsync(JobCategory entity)
        {
            return await unitOfWork.JobCategories.UpdateAsync(entity);

        }


        public async Task<bool> IsExist(int id)
        {
            return await unitOfWork.JobCategories.IsExist(id);
        }
    }
}
