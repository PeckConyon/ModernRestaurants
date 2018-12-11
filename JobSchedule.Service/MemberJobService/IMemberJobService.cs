using JobSchedule.Entities.Models;
using JobSchedule.Service.BaseService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JobSchedule.Service.MemberJobService
{
    public interface IMemberJobService : IService<MemberJob>
    {
        Task<IEnumerable<MemberJob>> GetAllJobMembersAsync();

        Task<MemberJob> GetJobMembersAsync(int id);

        Task<MemberJob> GetJobMemberByJobIdAsync(int id);
    }
}
