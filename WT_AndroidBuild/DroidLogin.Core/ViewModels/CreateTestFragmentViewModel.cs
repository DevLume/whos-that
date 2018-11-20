using Droid.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Core.ViewModels
{
    public class CreateTestFragmentViewModel : MvxViewModel
    {
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

        private string _author = LoginApp.loggedUserName;

        public string Author
        {
            get => _author;
            set
            {
                _author = value;
                RaisePropertyChanged(() => Author);
            }
        }

        public static event EventHandler<GetToCreateTestActivityArgs> OnRequestSent;

        private MvxCommand _createTestCommand;
        public MvxCommand CreateTestCommand
        {
            get
            {
                _createTestCommand = _createTestCommand ?? new MvxCommand(DoCreateTestCommand);
                return _createTestCommand;
            }
        }

        public void DoCreateTestCommand() //add async later
        {
            LoginApp.createTestName = _title;
            OnRequestSent?.Invoke(this, new GetToCreateTestActivityArgs(_title, _author));
        }

    }
}
