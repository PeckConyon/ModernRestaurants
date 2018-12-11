
using JobSchedule.Context.Repositories.BaseRepository.AwardRepo;
using JobSchedule.Context.Repositories.BaseRepository.FamilyMemberRepo;
using JobSchedule.Context.Repositories.BaseRepository.FamilyMemberRoleRepo;
using JobSchedule.Context.Repositories.BaseRepository.FamilyRepo;
using JobSchedule.Context.Repositories.BaseRepository.GoalRepo;
using JobSchedule.Context.Repositories.BaseRepository.JobCategoryRepo;
using JobSchedule.Context.Repositories.BaseRepository.JobRepo;
using JobSchedule.Context.Repositories.BaseRepository.JobTemplateRepo;
using JobSchedule.Context.Repositories.BaseRepository.MemberGoalRepo;
using JobSchedule.Context.Repositories.BaseRepository.MemberJobRepo;
using System;
using System.Threading.Tasks;

namespace JobSchedule.Context.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IAwardRepository Awards { get; }
        IFamilyMemberRepository FamilyMembers { get;}
        IFamilyMemberRoleRepository FamilyMemberRoles { get;}
        IFamilyRepository Families { get;}
        IGoalRepository Goals { get;}
        IJobCategoryRepository JobCategories { get;}
        IJobRepository Jobs { get;}
        IJobTemplateRepository JobTemplates { get;}
        IMemberJobRepository MemberJobs { get; }
        IMemberGoalRepository MemberGoals { get; }

        Task<int>  SaveChangesAsync();
    }
}
