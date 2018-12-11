using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobSchedule.Context.UnitOfWork;
using JobSchedule.Entities.Models;

namespace JobSchedule.Service.GoalService
{
    public class GoalSerive : IGoalSerive
    {
        private readonly IUnitOfWork unitOfWork;

        public GoalSerive(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<Goals> AddAsync(Goals entity)
        {
            return await  unitOfWork.Goals.AddAsync(entity);
        }

        public async Task<IEnumerable<Goals>> GetAllAsync()
        {
            return await unitOfWork.Goals.GetAllAsync();
        }

        public async Task<Goals> GetAsync(int id)
        {
            return await unitOfWork.Goals.GetAsync(id);
        }

        public async Task<Goals> RemoveAsync(Goals entity)
        {
            return await unitOfWork.Goals.RemoveAsync(entity);
        }

        public async Task<Goals> UpdateAsync(Goals entity)
        {
            return await unitOfWork.Goals.UpdateAsync(entity);
        }

        public async Task<bool> IsExist(int id)
        {
            return await unitOfWork.Goals.IsExist(id);
        }

        public async Task<IEnumerable<Goals>> GetAllWithAwardsAsync()
        {
            return await unitOfWork.Goals.GetAllGoalsWithAwardAsync();
        }

        public async Task<Goals> GetWithAwardAsync(int id)
        {
            return await unitOfWork.Goals.GetWithAwardAsync(id);
        }

        //public async Task<IEnumerable<Goals>> GetAllWithAwardsAsync()
        //{
        //    List<Goals> entity = await context.Set<FamilyMember>()
        //                                   .Include(f => f.Family)
        //                                   .Include(f => f.Role)
        //                                   .ToListAsync()
        //                                   .ConfigureAwait(false);

        //    return entity.AsEnumerable();
        //}
    }
}
