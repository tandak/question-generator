using Microsoft.AspNetCore.Mvc;
using QuestionGenerator.Lib;
using QuestionGenerator.Lib.Models;
using static QuestionGenerator.Lib.Mappers.QuestionMapper;

namespace QuestionGeneratorWebApp.Controllers
{
    [Route("hellotanda/questiongenerator/v1/question/")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionComposer _questionComposer;

        public QuestionController(IQuestionComposer questionComposer)
        {
            _questionComposer = questionComposer;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Question> Get(int id)
        {
            if (!IsValidateQuestionTypeRequestId(id))
            {
                return BadRequest("404 - NOT A VALID QUESTION MATE");
            }

            var requestedQuestionType = (QuestionType)id;
            var question = _questionComposer.ReturnQuestion(requestedQuestionType);

            var result = Map(question, requestedQuestionType);

            return Ok(result);
        }

        private static bool IsValidateQuestionTypeRequestId(int input)
        {
            return input > 0 && input < 6;
        }
    }
}