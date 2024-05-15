using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApplicationForm.Domain.Models
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }
        public string QuestionType { get; set; } = string.Empty;
        public string QuestionText { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public int MaxChoiceAllowed { get; set; } 

        public List<Choice>? Choices { get; set; } 

    }
}
