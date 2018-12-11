using System.Threading.Tasks;
using System;
using JobSchedule.Context.Context;
using JobSchedule.Context.Repositories.BaseRepository.AwardRepo;
using JobSchedule.Context.Repositories.BaseRepository.FamilyMemberRepo;
using JobSchedule.Context.Repositories.BaseRepository.FamilyMemberRoleRepo;
using JobSchedule.Context.Repositories.BaseRepository.FamilyRepo;
using JobSchedule.Context.Repositories.BaseRepository.GoalRepo;
using JobSchedule.Context.Repositories.BaseRepository.JobRepo;
using JobSchedule.Context.Repositories.BaseRepository.JobTemplateRepo;
using JobSchedule.Context.Repositories.BaseRepository.JobCategoryRepo;
using JobSchedule.Context.Repositories.BaseRepository.MemberJobRepo;
using JobSchedule.Context.Repositories.BaseRepository.MemberGoalRepo;

namespace JobSchedule.Context.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly JobDBContext context;

        public IAwardRepository Awards { get; private set; }
        public IFamilyMemberRepository FamilyMembers { get; private set; }
        public IFamilyMemberRoleRepository FamilyMemberRoles { get; private set; }
        public IFamilyRepository Families { get; private set; }
        public IGoalRepository Goals { get; private set; }
        public IJobCategoryRepository JobCategories { get; private set; }
        public IJobRepository Jobs { get; private set; }
        public IJobTemplateRepository JobTemplates { get; private set; }
        public IMemberJobRepository MemberJobs { get; private set; }
        public IMemberGoalRepository MemberGoals { get; private set; }

        public UnitOfWork(JobDBContext _context)
        {
            context = _context;

            Awards = new AwardRepository(context);
            FamilyMembers = new FamilyMemberRepository(context);
            FamilyMemberRoles = new FamilyMemberRoleRepository(context);
            Families = new FamilyRepository(context);
            Goals = new GoalRepository(context);
            JobCategories = new JobCategoryRepository(context);
            Jobs = new JobRepository(context);
            JobTemplates = new JobTemplateRepository(context);
            MemberJobs = new MemberJobRepository(context);
            MemberGoals = new MemberGoalRepository(context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
      
        public void Dispose()
        {
            context.Dispose();
        }

        
    }
}

