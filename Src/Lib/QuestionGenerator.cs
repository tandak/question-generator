using System;

namespace QuestionGenerator.Lib
{
    public interface IQuestionGenerator
    {
        string ReturnQuestion(QuestionType questionType);
    }

    public class QuestionGenerator : IQuestionGenerator
    {
        private readonly IQuestionRepository _repository = new QuestionRepository();

        public string ReturnQuestion(QuestionType questionType)
        {
            if (questionType == QuestionType.Random)
            {
                questionType = GetRandomQuestionType();
            }

            switch (questionType)
            {
                case QuestionType.NeverHaveIEver:
                    return _repository.ReturnNeverHaveIEver();
                case QuestionType.MostLikely:
                    return _repository.ReturnMostLikely();
                case QuestionType.Confess:
                    return _repository.ReturnConfession();
                case QuestionType.Task:
                    return _repository.ReturnTask();
                default:
                   throw new Exception();
            }
        }

        private static QuestionType GetRandomQuestionType()
        { 
            var selector = new Random();
            return (QuestionType)selector.Next(1, 4);
        }
    }
}