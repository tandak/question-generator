﻿using System;
using System.Reflection;
using QuestionGenerator.Lib;
using QuestionGenerator.Lib.Models;
using QuestionGenerator.Lib.Repository;

namespace QuestionGenerator.ConsoleApp
{
    public class Program
    {
        private static void Main(string[] args)
        {
           var repository = new QuestionRepository();
           var questionComposer = new QuestionComposer(repository);

            PrintAppInformation();

            while (true)
            {
                Console.Write("INPUT QUESTION TYPE:");

                var line = Console.ReadLine();

                if (line == "end")
                {
                    Console.WriteLine("THANKS FOR PLAYING!");
                    break;
                }

                var questionType = (QuestionType)Enum.Parse(typeof(QuestionType), line);
                var result = questionComposer.ReturnQuestion(questionType);
                Console.WriteLine(result);
            }
        }

        private static void PrintAppInformation()
        {
            var versionString = Assembly.GetEntryAssembly()
                .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                .InformationalVersion;
            Console.WriteLine($"CONFESS OR DRINK - QUESTION GENERATOR v{versionString}");
            Console.WriteLine("==========================================");
            Console.WriteLine($"QUESTION TYPES: --> OPTIONS: 1 - NEVER  HAVE I EVER | 2 - MOST LIKELY | 3 - CONFESS OR DRINK | 4 - TASK | 5 - CHOOSE FOR ME ");
        }
    }
}