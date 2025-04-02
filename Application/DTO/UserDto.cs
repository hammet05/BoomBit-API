using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TestBoomBit.Application.DTO
{
    public class UserDto
    {
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
