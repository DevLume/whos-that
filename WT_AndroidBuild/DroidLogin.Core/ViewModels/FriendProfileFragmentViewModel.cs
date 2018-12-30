using Android.Graphics;
using Droid.Core.Services;
using Droid.Core.Tools;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Core.ViewModels
{
    public class FriendProfileFragmentViewModel : MvxViewModel
    {
        private UserProfile _profileData;
        private IProfileService _profileService;
        private IFriendRqService _friendRqService;
        public FriendProfileFragmentViewModel(IProfileService profileService, IFriendRqService friendRqService)
        {
            _profileService = profileService;
            _friendRqService = friendRqService;
            ShowProfile();

            // _username = "test";
            _description = "test description";
        }

        public async void ShowProfile()
        {
            _profileData = await _profileService.GetUserProfile(LoginApp.profileUserName);

            _username = _profileData.username;
            _description = _profileData.description;
            byte[] pic = Convert.FromBase64String(_profileData.picBase64);
            _userpic = BitmapFactory.DecodeByteArray(pic, 0, pic.Length);
            _testTitles = _profileData.testList; // pass test additionally
            await RaiseAllPropertiesChanged();
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

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                RaisePropertyChanged(() => Username);
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                RaisePropertyChanged(() => Description);
            }
        }

        private Bitmap _userpic;
        public Bitmap Userpic
        {
            get => _userpic;
            set
            {
                _userpic = value;
                RaisePropertyChanged(() => Userpic);
            }
        }

        private MvxCommand _goToSelectedTest;
        public MvxCommand GoToSelectedTest
        {
            get
            {
                _goToSelectedTest = _goToSelectedTest ?? new MvxCommand(DoSolveTest);
                return _goToSelectedTest;
            }
        }

        private MvxCommand _sendFriendRq;
        public MvxCommand SendFriendRq
        {
            get
            {
                _sendFriendRq = _sendFriendRq ?? new MvxCommand(DoSendRq);
                return _sendFriendRq;
            }
        }

        public static event EventHandler<GuessTestRequestArgs> OnTestSolve;
        public static event EventHandler<MessageArgs> OnFriendRq;

        public void DoSolveTest() {
            LoginApp.guessTestAuthorName = _username;
            LoginApp.guessTestName = _title;
            OnTestSolve?.Invoke(this, new GuessTestRequestArgs(true, _title, _username));
        }

        public void DoSendRq()
        {
            _friendRqService.AddFriend(LoginApp.loggedUserName, _username);
            OnFriendRq?.Invoke(this, new MessageArgs("New friend has been added!"));
        }
    }
}
