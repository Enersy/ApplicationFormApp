using EmployeeApplicationForm.Domain.Models;
using EmplpyeeApplicationForm.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;



// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeApplicationForm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionRepository _questionRepository;
        
        public QuestionController(IQuestionRepository questionRepository)
        {
            _questionRepository = questionRepository;
            
        }
        // GET: api/<QuestionController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var questionList = await _questionRepository.GetAll();
            if (questionList == null)
            {
                return NotFound();
            }
          
            return Ok( questionList);
        }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty) return BadRequest($"{nameof(id)} is required.");

            var result = await _questionRepository.GetById(id);

            if (result == null) return NotFound();
    
            return  Ok(result);
        }

        // POST api/<QuestionController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Question value)
        {

            var qest = new Question
            {
                Id = Guid.NewGuid(),
                QuestionType = value.QuestionType,
                QuestionText = value.QuestionText,
                Answer = value.Answer,
                Choices = new List<Choice>(value.Choices)
            };
            if (value.Choices.Count > value.MaxChoiceAllowed) return BadRequest($"{nameof(value.MaxChoiceAllowed)} of choice has been exceeded");
            _questionRepository.Add(value);
            return Ok();
        }

        // PUT api/<QuestionController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put(Guid id, [FromBody] Question value)
        {
            var result = await _questionRepository.Update(value);

            if (result == null) return BadRequest();

            return Ok(result);
        }

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest($"{nameof(id)} is required.");
            
            var result = await  _questionRepository.Delete(id);

            return Ok(result);

        }
    }
}
