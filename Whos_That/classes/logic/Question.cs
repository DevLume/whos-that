using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Whos_that
{
    //put questions in separate objects, and create list of questions
    public class Question
    {
        public string QuestionText { get; set; }
        public string AnswerA { get; set; }
        public string AnswerB { get; set; }
        public string AnswerC { get; set; }
        public string AnswerD { get; set; }
        public int CorrectAnswerNum { get; set; }

        public Question(string questionText, string answerA, string answerB, string answerC, string answerD, int correctAnswerNum)
        {
            QuestionText = questionText;
            AnswerA = answerA;
            AnswerB = answerB;
            AnswerC = answerC;
            AnswerD = answerD;
            CorrectAnswerNum = correctAnswerNum;
        }
    }
}