using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule.Context.Repositories.BaseRepository.MemberGoalRepo
{
    public class MemberGoalRepository : Repository<MemberGoal>, IMemberGoalRepository
    {
        public MemberGoalRepository(JobDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MemberGoal>> GetAllGoalMembersAsync()
        {
            List<MemberGoal> entity = await context.Set<MemberGoal>()
                                    .Include(m => m.Goal)
                                    .Include(m => m.Member)
                                    .Include(m => m.Member.Family)
                                    .ToListAsync()
                                    .ConfigureAwait(false);

            return entity.AsEnumerable();
        }

        public async Task<MemberGoal> GetGoalMembersAsync(int id)
        {
            var goalMember = await context.Set<MemberGoal>()
                .Include(m => m.Goal)
                .Include(m => m.Member)
                .Include(m => m.Member.Family)
                .FirstOrDefaultAsync(m => m.Id == id);

            return goalMember;
        }

        public async Task<MemberGoal> GetGoalMemberByGoalIdAsync(int id)
        {
            var MemberGoal = await context.Set<MemberGoal>()
                .Include(m => m.Goal)
                .Include(m => m.Member)
                .Include(m => m.Member.Family)
                .FirstOrDefaultAsync(m => m.GoalId == id);

            return MemberGoal;
        }


    }
}
