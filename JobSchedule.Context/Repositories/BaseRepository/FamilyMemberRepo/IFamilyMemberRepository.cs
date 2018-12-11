using JobSchedule.Entities.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JobSchedule.Context.Repositories.BaseRepository.FamilyMemberRepo
{
    public interface IFamilyMemberRepository : IRepository<FamilyMember>
    {
        Task<FamilyMember> GetFamilyWithRoleAsync(int id);

        Task<IEnumerable<FamilyMember>> GetFamilyWithRoleAllAsync();

        Task<Family> GetFamilyByMemberId(int id);
    }
}
