using Android.Graphics;
using Droid.Core.Services.Tools;
using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Droid.Core.ViewModels
{
    public class FriendlistFragmentViewModel : MvxViewModel
    {
        public static event EventHandler<FillFriendlistArgs> OnFriendlistFragmentStart;

        private IFriendlistService _IFriendlistService;
        private List<Friend> _friends;
        public List<Friend> Friends
        {
            get => _friends;
            set
            {
                _friends = value; RaisePropertyChanged(() => Friends);
            }
        }

        private List<FriendDisplay> _dispFriends;
        public List<FriendDisplay> DispFriends
        {
            get => _dispFriends;
            set
            {
                _dispFriends = value;
                RaisePropertyChanged(() => DispFriends);
            }
        }


        List<FriendDisplay> disp = new List<FriendDisplay>();

        public FriendlistFragmentViewModel(IFriendlistService friendlist)
        {
            _IFriendlistService = friendlist;

            ShowFriends();

            DispFriends = disp;
        }

        public FriendlistFragmentViewModel() { }

        public async void ShowFriends()
        {
            _friends = await GetFriendList();
            Bitmap bmp;
            foreach (Friend f in _friends)
            {
                byte[] byteArr = Convert.FromBase64String(f.imageBase64Code);
                bmp = BitmapFactory.DecodeByteArray(byteArr, 0, byteArr.Length);
                disp.Add(new FriendDisplay(bmp, f.username, f.message));
            }
            DispFriends = disp;
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

    public class FriendDisplay : MvxViewModel
    {
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

        private MvxCommand _goToProfileCommand;
        public MvxCommand GoToProfileCommand
        {
            get
            {
                _goToProfileCommand = _goToProfileCommand ?? new MvxCommand(checkProfile);
                return _goToProfileCommand;
            }
        }
        public static event EventHandler<ShowProfileArgs> OnProfileCheck;

        public void checkProfile()
        {
            LoginApp.profileUserName = _username;
            OnProfileCheck?.Invoke(this, new ShowProfileArgs(_username));

        }

        public FriendDisplay() { }
        public FriendDisplay(Bitmap bmp, string uname, string messg)
        {
            Userpic = bmp;
            Username = uname;
            Message = messg;
        }
    }
}
