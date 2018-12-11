using JobSchedule.Entities.Models;
using JobSchedule.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule.Service.GoalService
{
    public interface IGoalSerive : IService<Goals>
    {
        Task<Goals> GetWithAwardAsync(int id);

        Task<IEnumerable<Goals>> GetAllWithAwardsAsync();
    }
}
