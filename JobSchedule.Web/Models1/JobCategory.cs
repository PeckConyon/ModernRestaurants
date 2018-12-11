using System;
using System.Collections.Generic;

namespace JobSchedule.Web.Models1
{
    public partial class JobCategory
    {
        public JobCategory()
        {
            Job = new HashSet<Job>();
            JobTemplate = new HashSet<JobTemplate>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Desscription { get; set; }

        public ICollection<Job> Job { get; set; }
        public ICollection<JobTemplate> JobTemplate { get; set; }
    }
}
