using JobSchedule.Context.UnitOfWork;
using JobSchedule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule.Service.MemberGoalService
{
    public class MemberGoalService : IMemberGoalService
    {
        private readonly IUnitOfWork unitOfWork;

        public MemberGoalService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<MemberGoal> AddAsync(MemberGoal entity)
        {
            return await unitOfWork.MemberGoals.AddAsync(entity);
        }

        public async Task<IEnumerable<MemberGoal>> GetAllAsync()
        {
            return await unitOfWork.MemberGoals.GetAllAsync();
        }

        public async Task<IEnumerable<MemberGoal>> GetAllGoalMembersAsync()
        {
            return await unitOfWork.MemberGoals.GetAllGoalMembersAsync();
        }

        public async Task<MemberGoal> GetAsync(int id)
        {
            return await unitOfWork.MemberGoals.GetAsync(id);
        }

        public async Task<MemberGoal> GetGoalMemberByGoalIdAsync(int id)
        {
            return await unitOfWork.MemberGoals.GetGoalMemberByGoalIdAsync(id);
        }

        public async Task<MemberGoal> GetGoalMembersAsync(int id)
        {
            return await unitOfWork.MemberGoals.GetGoalMembersAsync(id);
        }

        public async Task<bool> IsExist(int id)
        {
            return await unitOfWork.MemberGoals.IsExist(id);
        }

        public async Task<MemberGoal> RemoveAsync(MemberGoal entity)
        {
            return await unitOfWork.MemberGoals.RemoveAsync(entity);
        }

        public async Task<MemberGoal> UpdateAsync(MemberGoal entity)
        {
            return await unitOfWork.MemberGoals.UpdateAsync(entity);
        }
    }
}
