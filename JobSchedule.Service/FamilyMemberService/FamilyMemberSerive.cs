using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JobSchedule.Context.UnitOfWork;
using JobSchedule.Entities.Models;

namespace JobSchedule.Service.FamilyMemberService
{
    public class FamilyMemberSerive : IFamilyMemberSerive
    {
        private readonly IUnitOfWork unitOfWork;

        public FamilyMemberSerive(IUnitOfWork _unitOfWork)
        {
            unitOfWork = _unitOfWork;
        }
        public async Task<FamilyMember> AddAsync(FamilyMember entity)
        {
           return await unitOfWork.FamilyMembers.AddAsync(entity);
        }

        public async Task<IEnumerable<FamilyMember>> GetAllFamilyWithRoleAsync()
        {
            return await unitOfWork.FamilyMembers.GetFamilyWithRoleAllAsync();
        }

        public async Task<IEnumerable<FamilyMember>> GetAllAsync()
        {
            return await unitOfWork.FamilyMembers.GetAllAsync();
        }

        public async Task<FamilyMember> GetAsync(int id)
        {
            return await unitOfWork.FamilyMembers.GetAsync(id);
        }

        public async Task<bool> IsExist(int id)
        {
            return await unitOfWork.FamilyMembers.IsExist(id);
        }

        public async Task<FamilyMember> RemoveAsync(FamilyMember entity)
        {
            return await unitOfWork.FamilyMembers.RemoveAsync(entity);
        }

        public async Task<FamilyMember> UpdateAsync(FamilyMember entity)
        {
            return await unitOfWork.FamilyMembers.UpdateAsync(entity);
        }

        public async Task<Family> GetFamilyByMemberId(int id)
        {
            return await unitOfWork.FamilyMembers.GetFamilyByMemberId(id);
        }
    }
}
