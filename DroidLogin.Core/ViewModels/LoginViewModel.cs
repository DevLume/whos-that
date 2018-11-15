using Droid.Core.Services;
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

        private string _username;
        private string _password;

        public static event EventHandler<SendLoginRequestArgs> OnRequestSent;
        public static event EventHandler<ChangeActivityArgs> OnActivityChange;

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

            if (answerTuple != null)
            {
                OnRequestSent?.Invoke(this, new SendLoginRequestArgs(answerTuple.Item1, answerTuple.Item2));
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

    public class SendLoginRequestArgs : EventArgs
    {
        public bool pass;
        public string response;    

        public SendLoginRequestArgs(bool pass, string response)
        {
            this.pass = pass;
            this.response = response;
        }

    }

    public class ChangeActivityArgs : EventArgs
    {}
}
