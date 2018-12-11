using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;

namespace JobSchedule.Context.Repositories.BaseRepository.FamilyMemberRoleRepo
{
    public class FamilyMemberRoleRepository : Repository<FamilyMemberRole>, IFamilyMemberRoleRepository
    {
        public FamilyMemberRoleRepository(JobDBContext context) : base(context)
        {
        }

    }
}
