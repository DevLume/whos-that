using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Core
{
    public class FillFriendlistArgs : EventArgs
    {
        public string picBase64;
        public string username;
        public string message;

        public FillFriendlistArgs(string picBase64, string username, string message)
        {
            this.picBase64 = picBase64;
            this.message = message;
            this.username = username;
        }
    }

    public class SendMessageArgs : EventArgs
    {
        public string response;

        public SendMessageArgs(string resp)
        {
            response = resp;
        }
    }

    public class ShowTempActivityArgs : EventArgs
    {
        public string message;

        public ShowTempActivityArgs(string message)
        {
            this.message = message;
        }
    }

    public class CreateTestRequestArgs : EventArgs
    {
        public bool pass;
        public string title;
        public CreateTestRequestArgs(bool pass, string title)
        {
            this.pass = pass;
            this.title = title;
        }
    }

    public class GetToCreateTestActivityArgs : EventArgs
    {
        public string title;
        public string author;

        public GetToCreateTestActivityArgs(string title, string author)
        {
            this.title = title;
            this.author = author;
        }
    }

    public class CreateTestEventArgs : EventArgs
    {
        public bool errors;
        public string response;

        public CreateTestEventArgs(bool errors, string response)
        {
            this.errors = errors;
            this.response = response;
        }
    }

    public class AddQuestionEventArgs : EventArgs
    {
        public bool errors;
        public string response;
        public AddQuestionEventArgs(bool error, string response)
        {
            errors = error;
            this.response = response;
        }
    }

    public class GuessTestRequestArgs : EventArgs
    {
        public bool pass;
        public string title;
        public string authorName;
        public GuessTestRequestArgs(bool pass, string title, string authorName)
        {
            this.pass = pass;
            this.title = title;
            this.authorName = authorName;
        }
    }

    public class WrongInputEventArgs : EventArgs
    {
        public bool error;
        public string response;

        public WrongInputEventArgs(bool error, string response)
        {
            this.error = error;
            this.response = response;
        }
    }

    public class EndTestEventArgs : EventArgs
    {
        public bool error;
        public string response;
        public int correctAnswerCount;
        public int questionCount;

        public EndTestEventArgs(bool error, string response, int correctAnswers, int questionCount)
        {
            this.error = error;
            this.response = response;
            this.correctAnswerCount = correctAnswers;
            this.questionCount = questionCount;
        }
    }

    public class SendLoginRequestArgs : EventArgs
    {
        public bool pass;
        public string username;
        public string response;

        public SendLoginRequestArgs(bool pass, string response, string username)
        {
            this.pass = pass;
            this.response = response;
            this.username = username;
        }

    }

    public class ChangeActivityArgs : EventArgs
    { }

    public class SendErrorArgs : EventArgs
    {
        public string errorInfo;

        public SendErrorArgs(string ei)
        {
            errorInfo = ei;
        }
    }

    public class SendRegisterRequestArgs
    {
        public bool pass;
        public string response;

        public SendRegisterRequestArgs(bool pass, string response)
        {
            this.pass = pass;
            this.response = response;
        }
    }
}
