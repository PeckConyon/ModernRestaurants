using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSchedule.Entities.Models
{
    [Table("JobCategory")]
    public class JobCategory :BaseEntity
    {
        public JobCategory()
        {
            Job = new HashSet<Job>();
            JobTemplate = new HashSet<JobTemplate>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(200)]
        public string Desscription { get; set; }

        public ICollection<Job> Job { get; set; }
        public ICollection<JobTemplate> JobTemplate { get; set; }
    }
}
