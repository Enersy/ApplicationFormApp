using EmployeeApplicationForm.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmplpyeeApplicationForm.Infrastructure.Interfaces
{
    public interface IQuestionRepository
    {
        Task Add(Question question);
        Task<IEnumerable<Question>> GetAll();
        Task<Question?> GetById(Guid questionId);
        Task<Question?> Update(Question question);
        Task<bool> Delete(Guid questionId);
    }
}
