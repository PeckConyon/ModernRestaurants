using JobSchedule.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSchedule.Context.Repositories.BaseRepository.GoalRepo
{
    public interface IGoalRepository : IRepository<Goals>
    {
        Task<Goals> GetWithAwardAsync(int id);

        Task<IEnumerable<Goals>> GetAllGoalsWithAwardAsync();
    }
}
