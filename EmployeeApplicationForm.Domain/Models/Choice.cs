using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplicationForm.Domain.Models
{
    public class Choice
    {
        [Key]
        public Guid Id { get; set; }
        public string ChoiceText { get; set; } = string.Empty;
        public string QuestionId { get; set; } = string.Empty;
    }
}
