using System;
using System.Collections.Generic;
using System.Linq;

namespace QuestionGenerator.Lib.Repository
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
        private const int Start = 0;
        private const string MostLikelyStartPhrase = "WHO HERE IS MOST LIKELY TO ";
        private const string ConfessStartPhrase = "CONFESS!! ";
        private const string NeverHaveIEverStartPhrase = "NEVER HAVE I EVER ";

        private readonly List<string> _confessions = new List<string>
            {"TELL US THE STORY OF YOUR FIRST KISS", 
                "TELL US THE LAST MEAL YOU ATE", "A SONG THAT REMINDS YOU OF YOUR EX" };

        private readonly List<string> _mostLikely = new List<string>
        {
            "MARRY SOMEONE FAMOUS",
            "CHEAT ON A PARTNER",
            "STOLEN FROM SOMEONE IN THIS GROUP"
        };

        private readonly List<string> _neverHaveIEver = new List<string>
        {
            "EATEN CHOCOLATE", "CHEATED ON A PARTNER",
            "GOT WITH SOMEONE I KNOW WAS IN A RELATIONSHIP",
            "FOUND A FRIEND’S BOYFRIEND/GIRLFRIEND ATTRACTIVE?",
            "CHEATED ON A TEST IN SCHOOL",
            "USED A FLAVORED CONDOM/LUBE "
        };

        private readonly List<string> _randomTask = new List<string>
        {
            "SHARE A JOKE WITH THE GROUP - IF NO - ONE LAUGHS ? DRINK PLEASE",
            "GUYS IN THE GROUP DOWN YOUR DRINKS!",
            "LUCKY YOU! POINT TO THE PERSON YOU WANT TO DOWN THEIR DRINK",
            "SHARE A JOKE WITH THE GROUP - IF NO - ONE LAUGHS ? DRINK PLEASE",
            "POINT TO THE PERSON IN THE GROUP WHO YOU WOULD LEAST TRUST AROUND YOUR PARTNER (NO EXPLANATION, JUST POINT)",
            "DO SQUATS UNTIL ITS YOUR TURN AGAIN",
            "ITS TIME TO RHYME...GO GO GO",
            "(TEAM TASK) NO-ONE CAN USE NAMES UNTIL ITS MY TURN AGAIN"
        };

        private readonly Random _selector = new Random();

        public string ReturnConfession()
        {
            if (!_confessions.Any()) return "YOU'VE ANSWERED ALL CONFESSION QUESTIONS - TRY ANOTHER CATEGORY";
            var index = _selector.Next(Start, _confessions.Count());

            var confession = _confessions.ElementAt(index);
            _confessions.RemoveAt(index);

            return ConfessStartPhrase + confession;
        }

        public string ReturnTask()
        {
            if (!_randomTask.Any()) return "YOU'VE ANSWERED ALL 'RANDOM TASK' QUESTIONS - TRY ANOTHER CATEGORY";
            var index = _selector.Next(Start, _randomTask.Count());

            var task = _randomTask.ElementAt(index);
            _randomTask.RemoveAt(index);

            return task;
        }

        public string ReturnMostLikely()
        {
            if (!_mostLikely.Any()) return "YOU'VE ANSWERED ALL 'MOST LIKELY' QUESTIONS - TRY ANOTHER CATEGORY";
            var index = _selector.Next(Start, _mostLikely.Count());

            var mostLikely = _mostLikely.ElementAt(index);
            _mostLikely.RemoveAt(index);

            return MostLikelyStartPhrase + mostLikely;
        }

        public string ReturnNeverHaveIEver()
        {
            if (!_neverHaveIEver.Any())
                return "YOU'VE ANSWERED ALL 'NEVER HAVE I EVER' QUESTIONS - TRY ANOTHER CATEGORY";
            var index = _selector.Next(Start, _neverHaveIEver.Count());

            var neverHaveIEver = _neverHaveIEver.ElementAt(index);
            _neverHaveIEver.RemoveAt(index);

            return NeverHaveIEverStartPhrase + neverHaveIEver;
        }
    }
}