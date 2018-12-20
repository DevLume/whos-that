using Droid.Core.Services;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Plugin.PictureChooser;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.ViewModels
{
    public class GuessTestFragmentViewModel : MvxViewModel
    {        
        //private ICreateTestService _ICreateTestService;
        private ITestListService _ITestListService;
        private IMvxPictureChooserTask _pictureChooserTask;


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

        public GuessTestFragmentViewModel(IMvxPictureChooserTask pic) 
        {
            _pictureChooserTask = pic;
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

        private MvxCommand _goToProfileCommand;
        public MvxCommand GoToProfileCommand
        {
            get
            {
                _goToProfileCommand = _goToProfileCommand ?? new MvxCommand(DoGetListCommand);
                return _goToProfileCommand;
            }
        }

        public void DoGetListCommand()
        {
            /* try
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
             }*/
            string username = _testAuthor;
            OnRecog?.Invoke(this, new ShowProfileArgs(username));
        }     

        public void DoCreateTestCommand()
        {
            LoginApp.guessTestAuthorName = _testAuthor;
            LoginApp.guessTestName = _title;
            OnRequestSent?.Invoke(this, new GuessTestRequestArgs(true, _title, _testAuthor));
        }


        private MvxCommand _takePictureCommand;
        public MvxCommand TakePictureCommand
        {
            get
            {
                _takePictureCommand = _takePictureCommand ?? new MvxCommand(DoTakePicture);
                return _takePictureCommand;
            }
        }

        private void DoTakePicture()
        {
            var task = Mvx.IoCProvider.Resolve<IMvxPictureChooserTask>();

            task.TakePicture(400, 95, OnPicture, () => { });
        }

        private MvxCommand _choosePictureCommand;

        public System.Windows.Input.ICommand ChoosePictureCommand
        {
            get
            {
                _choosePictureCommand = _choosePictureCommand ?? new MvxCommand(DoChoosePicture);
                return _choosePictureCommand;
            }
        }

        private void DoChoosePicture()
        {
            var task = Mvx.IoCProvider.Resolve<IMvxPictureChooserTask>();


            task.ChoosePictureFromLibrary(400, 95, OnPicture, () => { });
        }

        private byte[] _bytes;
        private object pic1;

        public byte[] Bytes
        {
            get { return _bytes; }
            set { _bytes = value; RaisePropertyChanged(() => Bytes); }
        }

        public static event EventHandler<ShowProfileArgs> OnRecog;

        private void OnPicture(Stream pictureStream)
        {
            var memoryStream = new MemoryStream();
            pictureStream.CopyTo(memoryStream);
            Bytes = memoryStream.ToArray();

            //find who's that here
            #region ultra-fake recog
            string username = "tonyMontana";
            LoginApp.profileUserName = "tonyMontana";
            OnRecog?.Invoke(this,new ShowProfileArgs(username));
            #endregion
        }
    }
}
