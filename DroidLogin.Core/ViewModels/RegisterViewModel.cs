using Droid.Core.Services;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.ViewModels
{
    public class RegisterViewModel : MvxViewModel
    {
        private IRegisterService _IRegisterService;

        public static event EventHandler<SendRegisterRequestArgs> OnRequestSent;

        private string _username;
        private string _password;
        private string _password1;
        private string _email;

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
        public string Password1
        {
            get => _password1;
            set
            {
                _password1 = value;
                RaisePropertyChanged(() => Password);
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        public RegisterViewModel(IRegisterService registerService)
        {
            _IRegisterService = registerService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
        }

        private MvxCommand _registerCommand;
        public MvxCommand RegisterCommand
        {
            get
            {
                _registerCommand = _registerCommand ?? new MvxCommand(DoRegisterCommand);
                return _registerCommand;
            }
        }

        public async void DoRegisterCommand()
        {
            Tuple<bool, string> answerTuple = null;

            if (_password != _password1)
            {
                OnRequestSent?.Invoke(this, new SendRegisterRequestArgs(false, "Passwords doesn't match!"));
            }
            else
            {
                try
                {
                    answerTuple = await _IRegisterService.SendRegisterRequest(_username, _password, _email);
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine("A null exception has occurred: ", ex);
                }

                if (answerTuple != null)
                {
                    OnRequestSent?.Invoke(this, new SendRegisterRequestArgs(answerTuple.Item1, answerTuple.Item2));
                }
            }
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
