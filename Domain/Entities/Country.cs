using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace TestBoomBit.Domain.Entities
{
    public class Country
    {
        [Key]
        public int IdCountry { get; set; }        
        public string? Code { get; set; }
        public string? CountryName { get; set; }
        public bool Status { get; set; }
    }
}
