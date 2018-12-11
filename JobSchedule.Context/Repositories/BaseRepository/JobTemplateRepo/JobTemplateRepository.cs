using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace JobSchedule.Context.Repositories.BaseRepository.JobTemplateRepo
{
    public class JobTemplateRepository : Repository<JobTemplate>, IJobTemplateRepository
    {
        public JobTemplateRepository(JobDBContext context) : base(context)
        {
        }


        public async Task<IEnumerable<JobTemplate>> GetAllWithCategoryAsync()
        {
            List<JobTemplate> entity = await context.Set<JobTemplate>()
                                       .Include(j => j.Category)
                                       .ToListAsync()
                                       .ConfigureAwait(false);

            return entity.AsEnumerable();
        }

        public async Task<JobTemplate> GetWithCategoryAsync(int id)
        {
            var job = await context.Set<JobTemplate>()
                .Include(j => j.Category)
                .FirstOrDefaultAsync(m => m.Id == id);

            return job;
        }


        public async Task<IEnumerable<JobTemplate>> GetAllCompletedJobsAsync()
        {
            List<JobTemplate> entity = await context.Set<JobTemplate>()
                                   .Where(t => t.DateCompleted <= DateTime.Now)
                                   .ToListAsync()
                                   .ConfigureAwait(false);

            return entity.AsEnumerable();
        }

   
    }
}
