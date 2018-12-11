using System;
using System.Collections.Generic;

namespace JobSchedule.Web.Models1
{
    public partial class FamilyMember
    {
        public FamilyMember()
        {
            MemberGoal = new HashSet<MemberGoal>();
            MemberJob = new HashSet<MemberJob>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public int FamilyId { get; set; }
        public int TotalPoints { get; set; }

        public Family Family { get; set; }
        public FamilyMemberRole Role { get; set; }
        public ICollection<MemberGoal> MemberGoal { get; set; }
        public ICollection<MemberJob> MemberJob { get; set; }
    }
}
