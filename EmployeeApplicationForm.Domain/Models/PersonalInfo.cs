using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplicationForm.Domain.Models
{
    public class PersonalInfo
    {
        public Guid Id { get; set; }
        public string ProgramType { get; set; } = string.Empty;
        public string ProgramDescription { get; set; } = string.Empty;
        public  string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public  string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Nationality { get; set; } = string.Empty;
        public string CurrentResidence { get; set; } = string.Empty;
        public string IdNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; } 
        public string Gender { get; set; } 
        public ICollection<Question>? Questions { get; set; } 


    }
}
