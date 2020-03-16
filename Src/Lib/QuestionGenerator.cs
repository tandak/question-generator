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
            string question;
            if (questionType == QuestionType.Random)
            {
                questionType = GetRandomQuestionType();
            }

            switch (questionType)
            {
                case QuestionType.NeverHaveIEver:
                    question = _repository.ReturnNeverHaveIEver();
                    return $"NEVER HAVE I EVER {question}";
                case QuestionType.MostLikely:
                    question = _repository.ReturnMostLikely();
                    return $"WHO HERE IS MOST LIKELY TO {question}";
                case QuestionType.Confess:
                    question = _repository.ReturnConfession();
                    return $"CONFESS {question}";
                case QuestionType.Task:
                    question = _repository.ReturnTask();
                    return $"TASK: {question}";
                default:
                    return "ERROR - TRY AGAIN";
            }
        }

        private QuestionType GetRandomQuestionType()
        { 
            var selector = new Random();
            return (QuestionType)selector.Next(1, 5);
        }
    }
}