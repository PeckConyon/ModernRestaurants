using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JobSchedule.Entities.Models
{
    public partial class MemberGoal : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }

        public int MemberId { get; set; }
        public int GoalId { get; set; }

        public Goals Goal { get; set; }
        public FamilyMember Member { get; set; }
    }
}
