using System.Diagnostics;
using System.Security.Principal;
using System;

namespace TestBoomBit.Application.DTO
{
    public class ActivitiesDto
    {
        //public int Activity_id { get; set; }
        public int IdUser { get; set; }
        public string? ActivityDescription { get; set; }
        public bool Status { get; set; }
    }

    public class ActivitiesDtoGet
    {
        public int UserId { get; set; }
        public string? User { get; set; }
        public string? ActivityDescription { get; set; }
        public DateTime? ActivityDate { get; set; }
    }
}
