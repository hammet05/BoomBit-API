using System.ComponentModel.DataAnnotations;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestBoomBit.Domain.Entities
{
    public class User
    {

        [Key]
        public int IdUser { get; set; }
        public string? IdCountry { get; set; }
        public string? UserName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? Phone { get; set; }
        public bool IsContacted { get; set; }
        public bool Status { get; set; }
    }
}
