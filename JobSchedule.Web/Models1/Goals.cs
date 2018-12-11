using System;
using System.Collections.Generic;

namespace JobSchedule.Web.Models1
{
    public partial class Goals
    {
        public Goals()
        {
            MemberGoal = new HashSet<MemberGoal>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int AwardId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateAwarded { get; set; }

        public Award Award { get; set; }
        public ICollection<MemberGoal> MemberGoal { get; set; }
    }
}
