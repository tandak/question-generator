using System;
using QuestionGenerator.Lib.Models;
using QuestionGenerator.Lib.Repository;

namespace QuestionGenerator.Lib
{
    public interface IQuestionComposer
    {
        string ReturnQuestion(QuestionType questionType);
    }

    public class QuestionComposer : IQuestionComposer
    {
        private readonly IQuestionRepository _repository;

        public QuestionComposer(IQuestionRepository repository)
        {
            _repository = repository;
        }

        public string ReturnQuestion(QuestionType questionType)
        {
            if (questionType == QuestionType.Random) questionType = GetRandomQuestionType();

            switch (questionType)
            {
                case QuestionType.NeverHaveIEver:
                    return _repository.GetNeverHaveIEverQuestion();
                case QuestionType.MostLikely:
                    return _repository.GetMostLikelyQuestion();
                case QuestionType.Confess:
                    return _repository.GetConfessionQuestion();
                case QuestionType.Task:
                    return _repository.GetTask();
                default:
                    return "";
            }
        }

        private static QuestionType GetRandomQuestionType()
        {
            var selector = new Random();
            return (QuestionType) selector.Next(1, 4);
        }
    }
}