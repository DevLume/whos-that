using Droid.Core.Services;
using Droid.Core.Services.Tools;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.ViewModels
{
    public class CreateMessageFragmentViewModel : MvxViewModel
    {
        private IMessagingService _messagingService;

        private List<string> _friendNames;
        public List<string> FriendNames
        {
            get => _friendNames;
            set
            {
                _friendNames = value;
                RaisePropertyChanged(() => FriendNames);
            }
        }

        private string _recipient;
        public string Recipient
        {
            get => _recipient;
            set
            {
                _recipient = value;
                RaisePropertyChanged(() => Recipient);
            }
        }

        private string _message;
        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                RaisePropertyChanged(() => Message);
            }
        }

        public CreateMessageFragmentViewModel(IMessagingService messagingService, IFriendlistService friendlistService)
        {
            Task.Run(
                async () =>
                {
                    await GetFriends(friendlistService);
                });

            _messagingService = messagingService;
            _message = "test"; 
        }

        public async Task<bool> GetFriends(IFriendlistService friendlistService)
        {
            Tuple<bool, List<Friend>> friends = await friendlistService.GetFriendlist(LoginApp.loggedUserName);
            if (friends.Item1)
            {
                _friendNames = new List<string>();
                foreach (Friend f in friends.Item2)
                {
                    _friendNames.Add(f.username);
                }
                await RaiseAllPropertiesChanged();
                return true;
            }
            else return false;
        }

        private MvxCommand _sendMessageCommand;
        public MvxCommand SendMessageCommand
        {
            get
            {
                _sendMessageCommand = _sendMessageCommand ?? new MvxCommand(DoSendMessageCommand);
                return _sendMessageCommand;
            }
        }

        public static event EventHandler<SendMessageArgs> OnMessageSent;

        public async void DoSendMessageCommand()
        {
            try {
                bool success = await _messagingService.SendMessage(LoginApp.loggedUserName, _recipient, _message);

                if(success)
                {
                    OnMessageSent?.Invoke(this, new SendMessageArgs("Message is sent!"));
                }
                else
                {
                    OnMessageSent?.Invoke(this, new SendMessageArgs("Message could not be sent"));
                }
            }
            catch (NullReferenceException) {
                OnMessageSent?.Invoke(this, new SendMessageArgs("All fields must be filled"));
            }
        }
    }
}
