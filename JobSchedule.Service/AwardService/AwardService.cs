using JobSchedule.Context.UnitOfWork;
using JobSchedule.Entities.Models;
using JobSchedule.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule.Service.AwardService
{
    public class AwardService :  IAwardService
    {
        private readonly IUnitOfWork unitOfWork;

        public AwardService(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<Award> AddAsync(Award entity)
        {
            return await unitOfWork.Awards.AddAsync(entity);
        }

        public async Task<IEnumerable<Award>> GetAllAsync()
        {
            return await unitOfWork.Awards.GetAllAsync();
        }

        public async Task<Award> GetAsync(int id)
        {
            return await unitOfWork.Awards.GetAsync(id);
        }


        public async Task<Award> RemoveAsync(Award entity)
        {
            return await unitOfWork.Awards.RemoveAsync(entity);
        }

        public async Task<Award> UpdateAsync(Award entity)
        {
            return await unitOfWork.Awards.UpdateAsync(entity);
        }

        public async Task<bool> IsExist(int id)
        {
            return await unitOfWork.Awards.IsExist(id);
        }
    }
}
