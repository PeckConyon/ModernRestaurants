using JobSchedule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule.Context.Repositories.BaseRepository.MemberGoalRepo
{
    public interface IMemberGoalRepository : IRepository<MemberGoal>
    {
        Task<IEnumerable<MemberGoal>> GetAllGoalMembersAsync();

        Task<MemberGoal> GetGoalMembersAsync(int id);

        Task<MemberGoal> GetGoalMemberByGoalIdAsync(int id);

    }
}
