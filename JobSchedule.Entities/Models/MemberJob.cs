using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSchedule.Entities.Models 
{
    public partial class MemberJob : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        [Required]
        public  int MemberId { get; set; }

        [Required]
        public int JobId { get; set; }

        public Job Job { get; set; }
        public FamilyMember Member { get; set; }
     
    }
}
