using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobSchedule.Context.UnitOfWork;
using JobSchedule.Entities.Models;

namespace JobSchedule.Service.FamilyMemberRoleService
{
    public class FamilyMemberRoleSerive : IFamilyMemberRoleSerive
    {
        private readonly IUnitOfWork unitOfWork;

        public FamilyMemberRoleSerive(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }


        public async Task<FamilyMemberRole> AddAsync(FamilyMemberRole entity)
        {
            return await unitOfWork.FamilyMemberRoles.AddAsync(entity);
        }

        public async Task<IEnumerable<FamilyMemberRole>> GetAllAsync()
        {
            return await unitOfWork.FamilyMemberRoles.GetAllAsync();
        }

        public async Task<FamilyMemberRole> GetAsync(int id)
        {
            return await unitOfWork.FamilyMemberRoles.GetAsync(id);
        }

        public async Task<FamilyMemberRole> RemoveAsync(FamilyMemberRole entity)
        {
            return await unitOfWork.FamilyMemberRoles.RemoveAsync(entity);
        }

        public async Task<FamilyMemberRole> UpdateAsync(FamilyMemberRole entity)
        {
            return await unitOfWork.FamilyMemberRoles.UpdateAsync(entity);
        }

        public async Task<bool> IsExist(int id)
        {
            return await unitOfWork.FamilyMemberRoles.IsExist(id);
        }
    }
}
