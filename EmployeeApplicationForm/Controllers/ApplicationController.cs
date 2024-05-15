using EmployeeApplicationForm.Domain.Models;
using EmplpyeeApplicationForm.Infrastructure.Interfaces;
using EmplpyeeApplicationForm.Infrastructure.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApplicationForm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IPersonalInfoRepository _personalInfo;

        public ApplicationController(IPersonalInfoRepository personalRepository)
        {
           _personalInfo = personalRepository;

        }
        // GET: api/<QuestionController>
        //[HttpGet]
        //public async Task<IActionResult> Get()
        //{
        //    var result  = await_personalInfo.GetAll();
        //    if (questionList == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(questionList);
       // }

        // GET api/<QuestionController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(Guid id)
        {
            if (id == Guid.Empty) return BadRequest($"{nameof(id)} is required.");

            var result = await _personalInfo.GetById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        // POST api/<QuestionController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] PersonalInfo value)
        {

           // var qest = new Question
           // {
           //     Id = Guid.NewGuid(),
           //     QuestionType = value.QuestionType,
           //     QuestionText = value.QuestionText,
           //     Answer = value.Answer,
           //     Choices = new List<Choice>(value.Choices)
           // };
           // if (value.Choices.Count > value.MaxChoiceAllowed) return BadRequest($"{nameof(value.MaxChoiceAllowed)} of choice has been exceeded");
           //_personalInfo.Add(value);
            return Ok();
        }

        

        // DELETE api/<QuestionController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty) return BadRequest($"{nameof(id)} is required.");

            var result = await _personalInfo.Delete(id);

            return Ok(result);

        }
    }
}
