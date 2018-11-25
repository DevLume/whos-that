using Acr.UserDialogs;
using Droid.Core.Services;
using Droid.Core.Services.ViewEvent;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Droid.Core.ViewModels
{
    public class LoginViewModel : MvxViewModel
    {
        private ILoginService _ILoginService;
       // private ILoginEventManager _ILoginEventMan;

        private string _username;
        private string _password;

        public static event EventHandler<SendLoginRequestArgs> OnRequestSent;
        public static event EventHandler<ChangeActivityArgs> OnActivityChange;
        public static event EventHandler<SendErrorArgs> OnError;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged(() => Username);
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                RaisePropertyChanged(() => Password);
            }
        }

        public LoginViewModel(ILoginService logService)
        {
            _ILoginService = logService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }

        private void RequestLogin()
        {
            _ILoginService.SendLoginRequest(_username, _password);
        }

        private MvxCommand _loginCommand;
        public MvxCommand LoginCommand
        {
            get
            {
                _loginCommand = _loginCommand ?? new MvxCommand(DoCommand);
                return _loginCommand;
            }
        }
        
        public async void DoCommand()
        {
            Tuple<bool, string> answerTuple = null;
            try
            {
                answerTuple = await _ILoginService.SendLoginRequest(_username, _password);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("A null exception has occurred: ", ex);
            }
            catch (ArgumentNullException)
            {
                OnError?.Invoke(this, new SendErrorArgs("Please fill all fields!"));
            }

            if (answerTuple != null)
            {
                if (answerTuple.Item1)
                {
                    LoginApp.loggedUserName = _username;
                }
                OnRequestSent?.Invoke(this, new SendLoginRequestArgs(answerTuple.Item1, answerTuple.Item2, _username));
            }
        }

        private MvxCommand _switchToRegCommand;
        public MvxCommand SwitchToRegCommand
        {
            get
            {
                _switchToRegCommand = _switchToRegCommand ?? new MvxCommand(RegCommand);
                return _switchToRegCommand;
            }
        }

        public void RegCommand()
        {
            OnActivityChange?.Invoke(this, new ChangeActivityArgs());
        }
    }
}
