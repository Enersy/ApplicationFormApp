using EmployeeApplicationForm.Domain.Models;
using EmplpyeeApplicationForm.Infrastructure.Interfaces;

namespace EmplpyeeApplicationForm.Infrastructure.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly AppDbContext _appDbContext;
        public QuestionRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _appDbContext.Database.EnsureCreated();
        }
        public async Task Add(Question question)
        {
            
          Console.WriteLine(  _appDbContext.Add(question));
            await _appDbContext.SaveChangesAsync();
        }

        public async Task<Question?> GetById(Guid questionId)
        {
            var question =  await _appDbContext.Questions.FindAsync(questionId);
            var questionResult =await LoadQuestionWithReferences( question.Id);
            return questionResult;
        }

        private async Task<Question?> LoadQuestionWithReferences(Guid _questionId)
        {
            Question? question = await _appDbContext.Questions.FindAsync(_questionId); ;

            if (question == null) return null;
            if ( question.QuestionType == QuestionType.MultipleChoice.ToString() || question.QuestionType == QuestionType.DropDown.ToString())
            {
                if (question.QuestionType == QuestionType.DropDown.ToString())
                {
                    var questionEntry = _appDbContext.Questions.Entry(question);

                    if (questionEntry == null) return null;

                    await questionEntry
                    .Collection(x => x.Choices)
                    .LoadAsync();
                }

                if (question.QuestionType == QuestionType.MultipleChoice.ToString())              
                {
                 
                    var questionEntry = _appDbContext.Questions.Entry(question);

                    if (questionEntry == null) return null;

                    await questionEntry
                     .Collection(x => x.Choices)
                    .LoadAsync();
                }
            }
          
            return question;

        }

        public enum QuestionType
        {
            YesNo,
            DropDown,
            Paragraph,
            MultipleChoice,
            Date,
            Number
        }

        public async Task<Question?> Update(Question question)
        {
           var existingQuestion = await LoadQuestionWithReferences(question.Id);

            if (existingQuestion == null) return null;
            
            existingQuestion.QuestionText = question.QuestionText;
            existingQuestion.Choices = question.Choices;
            existingQuestion.Answer = question.Answer;
            existingQuestion.QuestionType = question.QuestionType;

           await _appDbContext.SaveChangesAsync();
            
          return existingQuestion;

        }

        public async Task<bool> Delete(Guid questionId)
        {
            var question = await _appDbContext.Questions.FindAsync(questionId);
            var questionResult = await LoadQuestionWithReferences(question.Id);

            if (questionResult == null) return false;

            _appDbContext.Questions.Remove(questionResult);

            await _appDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Question>> GetAll()
        {
          return  _appDbContext.Questions.ToList();
        }
    }
}
