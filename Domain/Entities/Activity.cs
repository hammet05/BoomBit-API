using System.ComponentModel.DataAnnotations;

namespace TestBoomBit.Domain.Entities
{
    public class Activity
    {
        [Key]
        public int ActivityId { get; set; }
        public int IdUser { get; set; }
        public string? ActivityDescription { get; set; }

        public DateTime DateCreated { get; set; }
        public bool Status { get; set; }
    }
}
