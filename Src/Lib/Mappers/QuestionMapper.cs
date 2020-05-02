using QuestionGenerator.Lib.Models;

namespace QuestionGenerator.Lib.Mappers
{
    public class QuestionMapper
    {
        public static Question Map(string result, QuestionType requestedQuestionType)
        {
            return new Question
            {
                QuestionType = requestedQuestionType.ToString(),
                Title = result
            };
        }
    }
}