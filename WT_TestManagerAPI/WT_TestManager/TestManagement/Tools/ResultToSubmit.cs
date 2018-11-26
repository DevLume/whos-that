///Result class, used to wrap user result class
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WT_TestManager.TestManagement.Tools
{
    public class ResultToSubmit
    {
        public string guessingUserName;
        public string authorName;
        public string testTitle;
        public int correctAnswerCount;
        public int questionCount;

        public ResultToSubmit(string guesser, string author, string title, int correctAnswers, int questionCount)
        {
            guessingUserName = guesser;
            authorName = author;
            testTitle = title;
            correctAnswerCount = correctAnswers;
            this.questionCount = questionCount;
        }
    }
}