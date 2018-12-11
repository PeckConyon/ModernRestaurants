using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSchedule.Context.Repositories.BaseRepository.GoalRepo
{
    public class GoalRepository : Repository<Goals>, IGoalRepository
    {
        public GoalRepository(JobDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Goals>> GetAllGoalsWithAwardAsync()
        {
            List<Goals> entity = await context.Set<Goals>()
                                         .Include(g => g.Award)
                                          .ToListAsync()
                                          .ConfigureAwait(false);

            return entity.AsEnumerable();
        }

        public async Task<Goals> GetWithAwardAsync(int id)
        {
            var goal = await context.Set<Goals>()
               .Include(g => g.Award)
               .FirstOrDefaultAsync(m => m.Id == id);

            return goal;
        }
    }
}
