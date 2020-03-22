using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using QuestionGenerator.Lib;
using QuestionGenerator.Lib.Model;

namespace QuestionGenerator.WebApi.Controllers
{
    [ApiController]
    [Route("api/question")]
    public class QuestionController : Controller
    {
        private readonly IQuestionGenerator _questionGenerator;

        public QuestionController(IQuestionGenerator questionGenerator)
        {
            _questionGenerator = questionGenerator;
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Question> Get(int id)
        {
            if (!IsValidateQuestionTypeRequestId(id))
            {
                return BadRequest(ModelState);
            }

            var requestedQuestionType = (QuestionType) id;
            var result = _questionGenerator.ReturnQuestion(requestedQuestionType);

            var question = MapResult(result, requestedQuestionType);

            return Ok(question);
        }

        private static Question MapResult(string result, QuestionType questionType)
        {
            return new Question
            {
                QuestionType = questionType.ToString(),
                question = result
            };
        }

        private static bool IsValidateQuestionTypeRequestId(int input)
        {
            return input > 0 && input < 5;
        }
    }
}
