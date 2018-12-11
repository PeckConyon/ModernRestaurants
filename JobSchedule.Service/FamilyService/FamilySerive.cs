using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobSchedule.Context.UnitOfWork;
using JobSchedule.Entities.Models;
using JobSchedule.Service.BaseService;

namespace JobSchedule.Service.FamilyService
{
    public class FamilySerive : IFamilySerive
    {
        private readonly IUnitOfWork unitOfWork;

        public FamilySerive(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }

        public async Task<Family> AddAsync(Family entity)
        {
            return await unitOfWork.Families.AddAsync(entity);
        }

        public async Task<IEnumerable<Family>> GetAllAsync()
        {
            return await unitOfWork.Families.GetAllAsync();
        }

        public async Task<Family> GetAsync(int id)
        {
            return await unitOfWork.Families.GetAsync(id);
        }

        public async Task<Family> RemoveAsync(Family entity)
        {
            return await unitOfWork.Families.RemoveAsync(entity);
        }

        public async Task<Family> UpdateAsync(Family entity)
        {
            return await unitOfWork.Families.UpdateAsync(entity);
        }

        public async Task<bool> IsExist(int id)
        {
            return await unitOfWork.Families.IsExist(id);
        }
    }
}
