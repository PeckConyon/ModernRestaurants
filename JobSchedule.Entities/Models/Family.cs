using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSchedule.Entities.Models
{
    [Table("Family")]
    public class Family: BaseEntity
    {
        public Family()
        {
            FamilyMember = new HashSet<FamilyMember>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<FamilyMember> FamilyMember { get; set; }
    }
}
