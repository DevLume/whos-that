using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Core.ViewModels
{
    public class GuessTestFragmentViewModel : MvxViewModel
    {
        //private ICreateTestService _ICreateTestService;

        private string _testAuthor;

        public string TestAuthor
        {
            get => _testAuthor;
            set
            {
                _testAuthor = value;
                RaisePropertyChanged(() => TestAuthor);
            }
        }

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                RaisePropertyChanged(() => Title);
            }
        }

        public static event EventHandler<GuessTestRequestArgs> OnRequestSent;

        private MvxCommand _guessTestCommand;
        public MvxCommand GuessTestCommand
        {
            get
            {
                _guessTestCommand = _guessTestCommand ?? new MvxCommand(DoCreateTestCommand);
                return _guessTestCommand;
            }
        }

        public void DoCreateTestCommand() //add async later
        {
            LoginApp.guessTestAuthorName = _testAuthor;
            LoginApp.guessTestName = _title;
            OnRequestSent?.Invoke(this, new GuessTestRequestArgs(true, _title, _testAuthor));
        }

    }
}
