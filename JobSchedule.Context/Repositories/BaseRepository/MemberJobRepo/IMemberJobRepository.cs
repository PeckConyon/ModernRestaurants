using JobSchedule.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule.Context.Repositories.BaseRepository.MemberJobRepo
{
    public interface IMemberJobRepository : IRepository<MemberJob>
    {
        Task<IEnumerable<MemberJob>> GetAllJobMembersAsync();

        Task<MemberJob> GetJobMembersAsync(int id);

        Task<MemberJob> GetJobMemberByJobIdAsync(int id);
    }
}
