using Droid.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.ViewModels
{
    public class GuessTestFragmentViewModel : MvxViewModel
    {        
        //private ICreateTestService _ICreateTestService;
        private ITestListService _ITestListService;

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

        public GuessTestFragmentViewModel(ITestListService tls)
        {
            _ITestListService = tls;
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

        private List<string> _testTitles;
        public List<string> TestTitles
        {
            get => _testTitles;
            set
            {
                _testTitles = value;
                RaisePropertyChanged(() => TestTitles);
            }
        }


        public static event EventHandler<GuessTestRequestArgs> OnRequestSent;
        public static event EventHandler<WrongInputEventArgs> OnWrongInput;

        private MvxCommand _guessTestCommand;
        public MvxCommand GuessTestCommand
        {
            get
            {
                _guessTestCommand = _guessTestCommand ?? new MvxCommand(DoCreateTestCommand);
                return _guessTestCommand;
            }
        }

        private MvxCommand _getTestListCommand;
        public MvxCommand GetTestListCommand
        {
            get
            {
                _getTestListCommand = _getTestListCommand ?? new MvxCommand(DoGetListCommand);
                return _getTestListCommand;
            }
        }

        public async void DoGetListCommand()
        {
            try
            {
                Tuple<List<string>, string> answerTuple = await _ITestListService.ListTests(_testAuthor);

                if (answerTuple.Item2 == null)
                {
                    _testTitles = answerTuple.Item1;
                    await RaiseAllPropertiesChanged();
                }
                else
                {
                    OnWrongInput?.Invoke(this, new WrongInputEventArgs(true, answerTuple.Item2));
                }
            }
            catch (NullReferenceException)
            {
                OnWrongInput?.Invoke(this, new WrongInputEventArgs(true, "Please enter author name first!"));
            }
        }     

        public void DoCreateTestCommand()
        {
            LoginApp.guessTestAuthorName = _testAuthor;
            LoginApp.guessTestName = _title;
            OnRequestSent?.Invoke(this, new GuessTestRequestArgs(true, _title, _testAuthor));
        }
    }
}
