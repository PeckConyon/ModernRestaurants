using JobSchedule.Entities.Models;
using JobSchedule.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule.Service.MemberGoalService
{
    public interface IMemberGoalService : IService<MemberGoal>
    {
        Task<IEnumerable<MemberGoal>> GetAllGoalMembersAsync();

        Task<MemberGoal> GetGoalMembersAsync(int id);

        Task<MemberGoal> GetGoalMemberByGoalIdAsync(int id);
    }
}
