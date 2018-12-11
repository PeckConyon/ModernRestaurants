using System;
using System.Collections.Generic;

namespace JobSchedule.Web.Models1
{
    public partial class Job
    {
        public Job()
        {
            MemberJob = new HashSet<MemberJob>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAssigned { get; set; }
        public DateTime? DateCompleted { get; set; }
        public int Points { get; set; }
        public int CategoryId { get; set; }

        public JobCategory Category { get; set; }
        public ICollection<MemberJob> MemberJob { get; set; }
    }
}
