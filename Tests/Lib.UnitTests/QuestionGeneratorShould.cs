using Xunit;

namespace QuestionGenerator.Lib.UnitTests
{
    public class QuestionGeneratorShould
    {
        [Theory]
        [InlineData(QuestionType.NeverHaveIEver, "NEVER HAVE I EVER")]
        [InlineData(QuestionType.MostLikely, "WHO HERE IS MOST LIKELY")]
        [InlineData(QuestionType.Confess, "CONFESS")]
        public void Return_Correct_Question_Type(QuestionType questionType, string expectedSubstring)
        {
            var game = new QuestionGenerator();
            var result = game.ReturnQuestion(questionType);

            Assert.Contains(expectedSubstring, result);
        }
    }
}