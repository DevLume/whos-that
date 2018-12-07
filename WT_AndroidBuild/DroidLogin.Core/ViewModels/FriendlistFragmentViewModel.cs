using Android.Graphics;
using Droid.Core.Services.Tools;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.ViewModels
{
    public class FriendlistFragmentViewModel : MvxViewModel
    {
        private IFriendlistService _IFriendlistService;
        private List<Friend> _friendlist;
        public List<Friend> Friendlist
        {
            get => _friendlist;
            set
            {
                _friendlist = value; RaisePropertyChanged(() => Friendlist);
            }
        }

        private byte[] _rawImage;
        public byte[] RawImage
        {
            get { return _rawImage; }
            set
            {
                _rawImage = value;
                if (_rawImage == null)
                    return;

                var bitmap = BitmapFactory.DecodeByteArray(_rawImage, 0, _rawImage.Length);
                RaisePropertyChanged(() => RawImage);
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

        private string _friendName;
        public string FriendName
        {
            get => _friendName;
            set
            {
                _friendName = value;
                RaisePropertyChanged(() => FriendName);
            }
        }


        private string _friendMessage;
        public string FriendMessage
        {
            get => _friendMessage;
            set
            {
                _friendMessage = value;
                RaisePropertyChanged(() => FriendMessage);
            }
        }

        public FriendlistFragmentViewModel(IFriendlistService friendlist)
        {
            _IFriendlistService = friendlist;
            ShowFriends();
        }

        public async void ShowFriends()
        {
            List<Friend> _friendlist = await GetFriendList();
            foreach (Friend f in _friendlist)
            {
                //TODO: write a script to add new users as grid layout 
                _friendName = f.username;
                _friendMessage = f.message;
                _rawImage = Convert.FromBase64String(f.imageBase64Code);
                _userpic = BitmapFactory.DecodeByteArray(_rawImage, 0, _rawImage.Length);
                await RaiseAllPropertiesChanged();
            }
        }

        public async Task<List<Friend>> GetFriendList()
        {
             Tuple<bool, List<Friend>> resultTuple = await _IFriendlistService.GetFriendlist(LoginApp.loggedUserName);

             if (resultTuple.Item1)
             {
                //all good
                return resultTuple.Item2;
             }
             else
             {
                //invoke error
                return null;
             }            
        }
    }
}
