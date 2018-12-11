using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSchedule.Entities.Models
{
    [Table("FamilyMember")]
    public  class FamilyMember :BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public int RoleId { get; set; }

        [Required]
        public int FamilyId { get; set; }

        public int TotalPoints { get; set; }

        public Family Family { get; set; }
        public FamilyMemberRole Role { get; set; }
        public ICollection<MemberGoal> MemberGoal { get; set; }
        public ICollection<MemberJob> MemberJob { get; set; }
    }
}
