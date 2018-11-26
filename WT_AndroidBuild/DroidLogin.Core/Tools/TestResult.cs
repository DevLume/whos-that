using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Core.Tools
{
    public class TestResult
    {
        public string guessingUserName;
        public string authorName;
        public string testTitle;
        public int correctAnswerCount;
        public int questionCount;

        public TestResult(string guesser, string author, string title, int correctAnswers, int questionCount)
        {
            guessingUserName = guesser;
            authorName = author;
            testTitle = title;
            correctAnswerCount = correctAnswers;
            this.questionCount = questionCount;
        }
    }
}
