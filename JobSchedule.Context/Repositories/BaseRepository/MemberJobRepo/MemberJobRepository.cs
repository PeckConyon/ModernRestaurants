using JobSchedule.Context.Context;
using JobSchedule.Context.Repositories.BaseRepository.JobTemplateRepo;
using JobSchedule.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule.Context.Repositories.BaseRepository.MemberJobRepo
{
    public class MemberJobRepository : Repository<MemberJob>, IMemberJobRepository
    {
        public MemberJobRepository(JobDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<MemberJob>> GetAllJobMembersAsync()
        {
            List<MemberJob> entity = await context.Set<MemberJob>()
                                      .Include(m => m.Job)
                                      .Include(m => m.Member)
                                      .Include(m => m.Member.Family)
                                      .ToListAsync()
                                      .ConfigureAwait(false);

            return entity.AsEnumerable();
        }


        public async Task<MemberJob> GetJobMembersAsync(int id)
        {
            var jobMember = await context.Set<MemberJob>()
                .Include(m => m.Job)
                .Include(m => m.Member)
                .Include(m => m.Member.Family)
                .FirstOrDefaultAsync(m => m.Id == id);

            return jobMember;
        }

        public async Task<MemberJob> GetJobMemberByJobIdAsync(int id)
        {
            var jobMember = await context.Set<MemberJob>()
                .Include(m => m.Job)
                .Include(m => m.Member)
                .Include(m => m.Member.Family)
                .FirstOrDefaultAsync(m => m.JobId == id);

            return jobMember;
        }
    }
}
