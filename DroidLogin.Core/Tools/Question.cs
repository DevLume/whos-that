using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Droid.Core.Tools
{
    public class Question
    {
        public Question(string question, string answer1, string answer2, string answer3, string answer4, int correctAnswerIndex)
        {
            this.question = question;
            this.answer1 = answer1;
            this.answer2 = answer2;
            this.answer3 = answer3;
            this.answer4 = answer4;
            this.correctAnswerIndex = correctAnswerIndex;
        }

        public string question { get; set; }
        public string answer1 { get; set; }
        public string answer2 { get; set; }
        public string answer3 { get; set; }
        public string answer4 { get; set; }
        public int correctAnswerIndex { get; set; }
    }
}