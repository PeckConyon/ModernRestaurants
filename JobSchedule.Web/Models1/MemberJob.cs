using System;
using System.Collections.Generic;

namespace JobSchedule.Web.Models1
{
    public partial class MemberJob
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int JobId { get; set; }

        public Job Job { get; set; }
        public FamilyMember Member { get; set; }
    }
}
