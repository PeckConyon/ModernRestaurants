using System;
using System.Collections.Generic;

namespace JobSchedule.Web.Models1
{
    public partial class Family
    {
        public Family()
        {
            FamilyMember = new HashSet<FamilyMember>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<FamilyMember> FamilyMember { get; set; }
    }
}
