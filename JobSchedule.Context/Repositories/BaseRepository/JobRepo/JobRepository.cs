using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSchedule.Context.Repositories.BaseRepository.JobRepo
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        public JobRepository(JobDBContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Job>> GetAllPendingJobsAsync()
        {
            List<Job> entity = await context.Set<Job>()
                                       .Where(j => j.DateCompleted ==null)
                                       .Where(j => j.MemberJob.Count()==0)
                                       .ToListAsync()
                                       .ConfigureAwait(false);

            return entity.AsEnumerable();
        }

        public  async Task<IEnumerable<Job>> GetAllWithCategoryAsync()
        {
            List<Job> entity = await context.Set<Job>()
                                       .Include(j => j.Category)
                                       .ToListAsync()
                                       .ConfigureAwait(false);

            return entity.AsEnumerable();
        }

        public async Task<Job> GetWithCategoryAsync(int id)
        {
            var job = await context.Set<Job>()
                .Include(j => j.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            return job;
        }
    }
}
