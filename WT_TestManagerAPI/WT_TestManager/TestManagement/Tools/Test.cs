using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WT_TestManager.TestManagement.Tools
{
    public class Test
    {
        public string author;
        public string title;

        public List<Question> questions;

        public Test(string title, string author, List<Question> questions)
        {
            this.title = title;
            this.author = author;
            this.questions = questions;
        }

        public void UpdateQuestionSet(Question question)
        {
            questions.Add(question);
        }
        public void UpdateQuestionSet(List<Question> questions)
        {
            questions.AddRange(questions);
        }

        public List<Question> GetQuestions()
        {
            return questions;
        }
    }
}