using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobSchedule.Context.UnitOfWork;
using JobSchedule.Entities.Models;

namespace JobSchedule.Service.MemberJobService
{
    public class MemberJobService : IMemberJobService
    {
        private readonly IUnitOfWork unitOfWork;

        public MemberJobService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        public async Task<MemberJob> AddAsync(MemberJob entity)
        {
            return await unitOfWork.MemberJobs.AddAsync(entity);
        }

        public async Task<IEnumerable<MemberJob>> GetAllAsync()
        {
            return await unitOfWork.MemberJobs.GetAllAsync();
        }

        public async Task<IEnumerable<MemberJob>> GetAllJobMembersAsync()
        {
            return await unitOfWork.MemberJobs.GetAllJobMembersAsync();
        }

        public async Task<MemberJob> GetAsync(int id)
        {
            return await unitOfWork.MemberJobs.GetAsync(id);
        }

        public async Task<MemberJob> GetJobMembersAsync(int id)
        {
            return await unitOfWork.MemberJobs.GetJobMembersAsync(id);
        }

        public async Task<bool> IsExist(int id)
        {
            return await unitOfWork.MemberJobs.IsExist(id);
        }

        public async Task<MemberJob> RemoveAsync(MemberJob entity)
        {
            return await unitOfWork.MemberJobs.RemoveAsync(entity);
        }

        public async Task<MemberJob> UpdateAsync(MemberJob entity)
        {
            return await unitOfWork.MemberJobs.UpdateAsync(entity);
        }

        public async Task<MemberJob> GetJobMemberByJobIdAsync(int id)
        {
            return await unitOfWork.MemberJobs.GetJobMemberByJobIdAsync(id);
        }
    }
}
