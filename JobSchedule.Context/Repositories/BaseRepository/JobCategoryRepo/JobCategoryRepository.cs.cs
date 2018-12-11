using JobSchedule.Context.Context;
using JobSchedule.Entities.Models;

namespace JobSchedule.Context.Repositories.BaseRepository.JobCategoryRepo
{
    public class JobCategoryRepository : Repository<JobCategory>, IJobCategoryRepository
    {
        public JobCategoryRepository(JobDBContext context) : base(context)
        {
        }

        public JobDBContext JobDBContext
        {
            get { return context as JobDBContext; }
        }

    }
}
