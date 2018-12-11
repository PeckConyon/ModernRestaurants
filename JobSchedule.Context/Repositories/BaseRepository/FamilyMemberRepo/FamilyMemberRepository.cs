using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSchedule.Context.Repositories.BaseRepository.FamilyMemberRepo
{
    public class FamilyMemberRepository : Repository<FamilyMember>, IFamilyMemberRepository
    {
        public FamilyMemberRepository(JobDBContext context) : base(context)
        {
        }

        public async Task<Family> GetFamilyByMemberId(int id)
        {
            var family = await context.Set<FamilyMember>()
                .Include(f => f.Family)
                .Where(m => m.Id == id)
                .Select(m => m.Family)
                .ToListAsync();

            return family?[0];
        }

        public async Task<IEnumerable<FamilyMember>> GetFamilyWithRoleAllAsync()
        {
            List<FamilyMember> entity = await context.Set<FamilyMember>()
                                            .Include(f => f.Family)
                                            .Include(f => f.Role)
                                            .ToListAsync()
                                            .ConfigureAwait(false);
        
            return entity.AsEnumerable();
    
        }

        public async Task<FamilyMember> GetFamilyWithRoleAsync(int id)
        {
            var familyMember = await context.Set<FamilyMember>()
                .Include(f => f.Family)
                .Include(f => f.Role)
                .FirstOrDefaultAsync(m => m.Id == id);

            return familyMember;
        }
    }
}
