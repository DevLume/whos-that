using Droid.Core.Services;
using Droid.Core.Tools;
using MvvmCross.Commands;
using MvvmCross.Plugin.PictureChooser;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Droid.Core.ViewModels
{
    public class ProfileBuilderViewModel : MvxViewModel
    {
        private readonly IMvxPictureChooserTask _pictureChooserTask;

        private IProfileBuilderService _service;
        public ProfileBuilderViewModel(IProfileBuilderService service, IMvxPictureChooserTask mvxPictureChooserTask)
        {
            _service = service;
            _pictureChooserTask = mvxPictureChooserTask;
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

        private MvxCommand _submitProfile;
        public MvxCommand SubmitProfile
        {
            get
            {
                _submitProfile = _submitProfile ?? new MvxCommand(DoSubmit);
                return _submitProfile;
            }
        }
        public static event EventHandler<SubmitProfileArgs> OnSubmitProfile;

        private async void DoSubmit()
        {
            UserProfile uprofile = new UserProfile();
            uprofile.username = LoginApp.loggedUserName;
            if (Description != null)
            {
                uprofile.description = Description;
            }
            if (Bytes != null)
            {
                uprofile.picBase64 = Convert.ToBase64String(Bytes);
            }
            await _service.UpdateProfile(uprofile);

            OnSubmitProfile?.Invoke(this, new SubmitProfileArgs());
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
            _pictureChooserTask.TakePicture(400,95, OnPicture, () => { });
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
            _pictureChooserTask.ChoosePictureFromLibrary(400, 95, OnPicture, () => { });
        }

        private byte[] _bytes;

        public byte[] Bytes
        {
            get { return _bytes; }
            set { _bytes = value; RaisePropertyChanged(() => Bytes); }
        }

        private void OnPicture(Stream pictureStream)
        {
            var memoryStream = new MemoryStream();
            pictureStream.CopyTo(memoryStream);
            Bytes = memoryStream.ToArray();
        }
    }
}
