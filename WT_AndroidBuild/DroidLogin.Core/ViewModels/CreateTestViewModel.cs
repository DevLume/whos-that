using Droid.Core.Services;
using Droid.Core.Tools;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.ViewModels
{
    public class CreateTestViewModel : MvxViewModel
    {
        private ICreateTestService _ICreateTestService;

        private string _question;
        public string Question
        {
            get => _question;
            set
            {
                _question = value;
                RaisePropertyChanged(() => Question);
            }
        }

        private string _answer1;
        public string Answer1
        {
            get => _answer1;
            set
            {
                _answer1 = value;
                RaisePropertyChanged(() => Answer1);
            }
        }

        private string _answer2;
        public string Answer2
        {
            get => _answer2;
            set
            {
                _answer2 = value;
                RaisePropertyChanged(() => Answer2);
            }
        }

        private string _answer3;
        public string Answer3
        {
            get => _answer3;
            set
            {
                _answer3 = value;
                RaisePropertyChanged(() => Answer3);
            }
        }

        private string _answer4;
        public string Answer4
        {
            get => _answer4;
            set
            {
                _answer4 = value;
                RaisePropertyChanged(() => Answer4);
            }
        }

        private int _answerIndex = 1;
        public int AnswerIndex
        {
            get => _answerIndex;
            set
            {
                _answerIndex = value;
                RaisePropertyChanged(() => AnswerIndex);
            }
        }


        public static event EventHandler<CreateTestEventArgs> OnCreateTest;
        public static event EventHandler<AddQuestionEventArgs> OnAddQuestion;
        public static event EventHandler<ShowTempActivityArgs> OnTestCreated;

        private MvxCommand _createTest;
        public MvxCommand CreateTest
        {     
            get
            {
                _createTest = _createTest ?? new MvxCommand(CreateTestCommand);
                return _createTest;
            }
        }

        private MvxCommand _addQuestion;
        public MvxCommand AddQuestion
        {
            get
            {
                _addQuestion = _addQuestion ?? new MvxCommand(AddQuestionCommand);
                return _addQuestion;
            }
        }

        public CreateTestViewModel(ICreateTestService cts)
        {
            _ICreateTestService = cts;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }


        private Test _test = new Test(LoginApp.createTestName,LoginApp.loggedUserName, new List<Question>());

        public async void CreateTestCommand()
        {
            Tuple<bool, string> answerTuple = null;

            try
            {
                answerTuple = await _ICreateTestService.SendCreateTestRequest(LoginApp.createTestName,LoginApp.loggedUserName,_test);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("A null exception has occurred: ", ex);
            }

            if (answerTuple != null)
            {
                if (answerTuple.Item1)
                {
                    OnCreateTest?.Invoke(this, new CreateTestEventArgs(false, "Test has been published!"));
                    OnTestCreated?.Invoke(this, new ShowTempActivityArgs("You have successfully created a test!"));
                }
                else
                {
                    OnCreateTest?.Invoke(this, new CreateTestEventArgs(true, "Test has not been published!"));
                }
            }
        }

        public void AddQuestionCommand()
        {
            try
            {
                if (_question == null || _answer1 == null || _answer2 == null || _answer3 == null || _answer4 == null)
                {
                    throw new NullReferenceException();
                }
                _test?.UpdateQuestionSet(new Tools.Question(_question,_answer1,_answer2,_answer3,_answer4,_answerIndex));
                
                OnAddQuestion?.Invoke(this, new AddQuestionEventArgs(false, "New Question was added to your test!"));
                _question = null;               
                _answer1 = null;
                _answer2 = null;
                _answer3 = null;
                _answer4 = null;
                _answerIndex = 1;
                RaiseAllPropertiesChanged();
            }
            catch (NullReferenceException)
            {
                OnAddQuestion?.Invoke(this, new AddQuestionEventArgs(true, "One or more fields are empty!"));
            }         
        }
    }
}
