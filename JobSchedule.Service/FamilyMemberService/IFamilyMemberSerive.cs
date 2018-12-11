using JobSchedule.Entities.Models;
using JobSchedule.Service.BaseService;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSchedule.Service.FamilyMemberService
{
    public interface IFamilyMemberSerive : IService<FamilyMember>
    {
        Task<IEnumerable<FamilyMember>> GetAllFamilyWithRoleAsync();

        Task<Family> GetFamilyByMemberId(int id);
    }
}
