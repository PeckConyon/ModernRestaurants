using System;
using System.Collections.Generic;

namespace JobSchedule.Web.Models1
{
    public partial class MemberGoal
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int GoalId { get; set; }

        public Goals Goal { get; set; }
        public FamilyMember Member { get; set; }
    }
}
