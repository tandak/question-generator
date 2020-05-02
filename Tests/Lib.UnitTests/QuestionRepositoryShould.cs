using FluentAssertions;
using QuestionGenerator.Lib.Repository;
using Xunit;

namespace QuestionGenerator.Lib.UnitTests
{
    public class QuestionRepositoryShould
    {
        private readonly IQuestionRepository _questionRepository;

        public QuestionRepositoryShould()
        {
            _questionRepository = new QuestionRepository();
        }

        [Fact]
        public void Return_Confession_Question()
        {
            var result = _questionRepository.GetConfessionQuestion();

            result.Should().Contain("CONFESS");
        }

        [Fact]
        public void Return_MostLikely_Question()
        {
            var result = _questionRepository.GetMostLikelyQuestion();

            result.Should().Contain("MOST LIKELY");
        }

        [Fact]
        public void Return_NeverHaveIEver_Question()
        {
            var result = _questionRepository.GetNeverHaveIEverQuestion();

            result.Should().Contain("NEVER HAVE I EVER");
        }

        [Fact]
        public void Return_A_Task()
        {
            var result = _questionRepository.GetTask();

            result.Should().Contain("TASK");
        }
    }
}