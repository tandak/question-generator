using Moq;
using QuestionGenerator.Lib.Models;
using QuestionGenerator.Lib.Repository;
using Xunit;

namespace QuestionGenerator.Lib.UnitTests
{
    public class QuestionComposerShould
    {
        private readonly Mock<IQuestionRepository> _questionRepositoryMock;
        private readonly QuestionComposer _questionComposer;

        public QuestionComposerShould()
        {
            _questionRepositoryMock = new Mock<IQuestionRepository>();
            _questionComposer = new QuestionComposer(_questionRepositoryMock.Object);
        }

        [Fact]
        public void Return_Expected_Confession_Question()
        {
            var expectedQuestion = "CONFESSION...ABC";

            _questionRepositoryMock.Setup(x => x.GetConfessionQuestion())
                .Returns(expectedQuestion);

            var result = _questionComposer.ReturnQuestion(QuestionType.Confess);

            Assert.Contains(expectedQuestion, result);
        }

        [Fact]
        public void Return_Expected_MostLikely_Question()
        {
            var expectedQuestion = "MOST LIKELY...ABC";

            _questionRepositoryMock.Setup(x => x.GetMostLikelyQuestion())
                .Returns(expectedQuestion);

            var result = _questionComposer.ReturnQuestion(QuestionType.MostLikely);

            Assert.Contains(expectedQuestion, result);
        }

        [Fact]
        public void Return_Expected_NeverHaveIEver_Question()
        {
            var expectedQuestion = "NEVER HAVE I EVER...ABC";

            _questionRepositoryMock.Setup(x => x.GetNeverHaveIEverQuestion())
                .Returns(expectedQuestion);

            var result = _questionComposer.ReturnQuestion(QuestionType.NeverHaveIEver);

            Assert.Contains(expectedQuestion, result);
        }

        [Fact]
        public void Return_Expected_Task_Question()
        {
            var expectedQuestion = "TASK...ABC";

            _questionRepositoryMock.Setup(x => x.GetTask())
                .Returns(expectedQuestion);

            var result = _questionComposer.ReturnQuestion(QuestionType.Task);

            Assert.Contains(expectedQuestion, result);
        }
    }
}