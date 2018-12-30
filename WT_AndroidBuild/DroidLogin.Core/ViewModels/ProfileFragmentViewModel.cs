using Android.Graphics;
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
    public class ProfileFragmentViewModel : MvxViewModel
    {
        private UserProfile _profileData;
        private IProfileService _profileService;
        public ProfileFragmentViewModel(IProfileService profileService)
        {
            _profileService = profileService;

          
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

            await RaiseAllPropertiesChanged();
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

        private MvxCommand _modifyProfile;
        public MvxCommand ModifyProfile
        {
            get
            {
                _modifyProfile = _modifyProfile ?? new MvxCommand(DoModifyProfile);
                return _modifyProfile;
            }
        }

        public static event EventHandler<ModifyProfileArgs> OnModifyProfile;

        private void DoModifyProfile()
        {
            OnModifyProfile?.Invoke(this, new ModifyProfileArgs(LoginApp.loggedUserName, _description, _userpic));
        }
    }
}
