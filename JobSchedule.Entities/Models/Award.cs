using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSchedule.Entities.Models
{
    [Table("Award")]
    public class Award: BaseEntity
    {
        public Award()
        {
            Goals = new HashSet<Goals>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public int Points { get; set; }

        public ICollection<Goals> Goals { get; set; }
    }
}
