using Droid.Core.Services;
using Droid.Core.Tools;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.ViewModels
{
    public class GuessTestViewModel : MvxViewModel
    {
        private IGuessTestService _IGuessTestService;
        private ISubmitResultService _ISubmitResultService;

        private string _questionCounterText;
        public string QuestionCounterText
        {
            get => _questionCounterText;
            set
            {
                _questionCounterText = value;
                RaisePropertyChanged(() => QuestionCounterText);
            }
        }

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

        private int _answerIndex = 0;
        public int AnswerIndex
        {
            get => _answerIndex;
            set
            {
                _answerIndex = value;
                RaisePropertyChanged(() => AnswerIndex);
            }
        }

        private void ShowQuestion(Question q)
        {
            _questionCounterText = string.Format("Question " + testPosition + " of " + _test.questions.Count);
            _question = q.question;
            _answer1 = q.answer1;
            _answer2 = q.answer2;
            _answer3 = q.answer3;
            _answer4 = q.answer4;
            _answerIndex = 1;
            RaiseAllPropertiesChanged();
        }

        private Test _test;
        private int testPosition = 0;
        private async Task GetTest(string author, string title)
        {
            Tuple<bool, List<Question>> resultTuple = await _IGuessTestService.GetTestToSolve(title, author);
            _test = new Test(title, author, resultTuple.Item2);
        }

        private Question GetNextQuestion()
        {
            Question q;
            try
            {
                q = _test.questions.ElementAt(testPosition);
                testPosition++;
            }
            catch (Exception)
            {
                q = _test.questions.First();
            }
            finally
            {
                if (testPosition == _test.questions.Count)
                {
                    //Show end test button
                    _hideButton = false;
                }               
            }
            return q;
        }

        public GuessTestViewModel(IGuessTestService gts, ISubmitResultService srs)
        {
            _IGuessTestService = gts;
            _ISubmitResultService = srs;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            await GetTest(LoginApp.guessTestAuthorName, LoginApp.guessTestName);
            ShowQuestion(GetNextQuestion());
            await RaiseAllPropertiesChanged();
        }

        private MvxCommand _nextQuestion;
        public MvxCommand NextQuestion
        {
            get
            {
                _nextQuestion = _nextQuestion ?? new MvxCommand(NextQuestionCommand);
                return _nextQuestion;
            }
        }

        private MvxCommand _endTest;
        public MvxCommand EndTest
        {
            get
            {
                _endTest = _endTest ?? new MvxCommand(EndTestCommand);
                return _endTest;
            }
        }     

        private List<int> _items = new List<int>()
        {
            1,2,3,4 
        };
        public List<int> Items
        {
            get { return _items; }
            set { _items = value; RaisePropertyChanged(() => Items); }
        }
        private int _selectedItem = 1;
        public int SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; RaisePropertyChanged(() => SelectedItem); _answerIndex = _selectedItem; }
        }

        private bool _hideButton = true;
        public bool HideButton
        {
            get => _hideButton;
            set
            {
                _hideButton = value; RaisePropertyChanged(() => HideButton);
            }
        } 

        private List<int> answerIndexes = new List<int>();

        public static event EventHandler<WrongInputEventArgs> OnWrongInput;
        public static event EventHandler<EndTestEventArgs> OnTestEnd;

        public void NextQuestionCommand()
        {       
            if (testPosition > 0 && testPosition <= 4)
            {
                answerIndexes.Add(_answerIndex);
            }

            if (_answerIndex == 0 || _answerIndex > 4 )
            {
                OnWrongInput?.Invoke(this, new WrongInputEventArgs(true, "Enter your answer [number from 1 to 4]"));
            }
            else
            {
                ShowQuestion(GetNextQuestion());         
                RaiseAllPropertiesChanged();
            }
        }

        public async void EndTestCommand()
        {
            int i = 0;
            int correctAnswers = 0;

            if (testPosition > 0 && testPosition <= 4)
            {
                answerIndexes.Add(_answerIndex);
            }

            if (_answerIndex == 0 || _answerIndex > 4)
            {
                OnWrongInput?.Invoke(this, new WrongInputEventArgs(true, "Enter your answer [number from 1 to 4]"));
            }

            foreach (Question q in _test.questions)
            {
                try
                {
                    if (q.correctAnswerIndex == answerIndexes[i])
                    {
                        correctAnswers++;
                    }
                    i++;
                }
                catch (Exception)
                {
                    OnWrongInput?.Invoke(this, new WrongInputEventArgs(true,"Answer at least one question"));
                }
            }

            Tuple<bool, string> resTuple = await _ISubmitResultService.SubmitResults(new TestResult(LoginApp.loggedUserName,
                LoginApp.guessTestAuthorName, LoginApp.guessTestName, correctAnswers, _test.questions.Count));

            if (resTuple.Item1 == true)
            {
                OnWrongInput?.Invoke(this, new WrongInputEventArgs(true, resTuple.Item2));
            }
            else
            {
                OnTestEnd?.Invoke(this, new EndTestEventArgs(false, resTuple.Item2, correctAnswers, _test.questions.Count));
            }
        }

    }  
}
