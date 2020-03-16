using System;
using System.Collections.Generic;

namespace QuestionGenerator.Lib
{
    public interface IQuestionRepository
    {
        string ReturnNeverHaveIEver();

        string ReturnMostLikely();

        string ReturnConfession();

        string ReturnTask();
    }

    public class QuestionRepository : IQuestionRepository
    {
        private const int Start = 1;

        private readonly Random _selector = new Random();

        private readonly IDictionary<int, string> _confessionQuestions = new Dictionary<int, string>
        {
            [1] = "TELL US THE STORY OF YOUR FIRST KISS"
        };

        private readonly IDictionary<int, string> _mostLikelyQuestions = new Dictionary<int, string>
        {
            [1] = "TO MARRY SOMEONE FAMOUS",
            [2] = "CHEAT ON A PARTNER",
            [3] = "STEAL FROM SOMEONE IN THIS GROUP"
        };

        private readonly IDictionary<int, string> _neverHaveIEverQuestions = new Dictionary<int, string>
        {
            [1] = "EATEN CHOCOLATE",
            [2] = "CHEATED ON A PARTNER",
            [3] = "GOT WITH SOMEONE I KNOW WAS IN A RELATIONSHIP",
            [4] = "FOUND A FRIEND’S BOYFRIEND/GIRLFRIEND ATTRACTIVE?",
            [5] = "CHEATED ON A TEST IN SCHOOL",
            [6] = "USED A FLAVORED CONDOM/LUBE "
        };

        private readonly  IDictionary<int, string> _randomTaskQuestions = new Dictionary<int, string>
        {
            [1] = "SHARE A JOKE WITH THE GROUP - IF NO - ONE LAUGHS ? DRINK PLEASE",
            [2] = "GUYS ON THE TABLE…DOWN YOUR DRINKS!",
            [3] = "LUCKY YOU! POINT TO THE PERSON YOU WANT TO DOWN THEIR DRINK",
            [4] = "SHARE A JOKE WITH THE GROUP - IF NO - ONE LAUGHS ? DRINK PLEASE",
            [5] = "POINT TO THE PERSON IN THE GROUP WHO YOU WOULD LEAST TRUST AROUND YOUR PARTNER (NO EXPLANATION, JUST POINT)",
            [6] = "DO SQUATS UNTIL ITS YOUR TURN AGAIN",
            [7] = "(TEAM TASK) NO-ONE CAN USE NAMES UNTIL ITS MY TURN AGAIN"
        };


        public string ReturnConfession()
        {
            return _confessionQuestions[_selector.Next(Start, _confessionQuestions.Count)];
        }

        public string ReturnTask()
        {
            return _randomTaskQuestions[_selector.Next(Start, _randomTaskQuestions.Count)];
        }

        public string ReturnMostLikely()
        {
            return _mostLikelyQuestions[_selector.Next(Start, _mostLikelyQuestions.Count)];
        }

        public string ReturnNeverHaveIEver()
        {
            return _neverHaveIEverQuestions[_selector.Next(Start, _neverHaveIEverQuestions.Count)];
        }
    }
}