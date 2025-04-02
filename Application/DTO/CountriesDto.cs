using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Numerics;
using System;

namespace TestBoomBit.Application.DTO
{
    public class CountriesDto
    {
        public int IdCountry { get; set; }
        public string? Code  { get; set; }
        public string? CountryName { get; set; }

        public bool Status { get; set; }

    }
}
