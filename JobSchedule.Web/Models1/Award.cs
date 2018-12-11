using System;
using System.Collections.Generic;

namespace JobSchedule.Web.Models1
{
    public partial class Award
    {
        public Award()
        {
            Goals = new HashSet<Goals>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }

        public ICollection<Goals> Goals { get; set; }
    }
}
