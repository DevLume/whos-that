using Droid.Core.Services;
using Droid.Core.Services.Tools;
using MvvmCross.Plugin.PictureChooser;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Core.ViewModels
{
    public class MainScreenViewModel : MvxViewModel
    {     
        private CreateTestFragmentViewModel _crt = new CreateTestFragmentViewModel();
        public CreateTestFragmentViewModel Crt
        {
            get => _crt;
            set
            {
                _crt = value; RaisePropertyChanged(() => Crt);
            }
        }

        private GuessTestFragmentViewModel _grt = new GuessTestFragmentViewModel(new TestListService());
        public GuessTestFragmentViewModel Grt
        {
            get => _grt;
            set
            {
                _grt = value; RaisePropertyChanged(() => Grt);
            }
        }

        private StatisticsFragmentViewModel _srt = new StatisticsFragmentViewModel(new StatisticsService());
        public StatisticsFragmentViewModel Srt
        {
            get => _srt;
            set
            {
                _srt = value; RaisePropertyChanged(() => Srt);
            }
        }

        private FriendlistFragmentViewModel _frt = new FriendlistFragmentViewModel(new FriendlistService());
        public FriendlistFragmentViewModel Frt
        {
            get => _frt;
            set
            {
                _frt = value; RaisePropertyChanged(() => Frt);
            }
        }

        private CreateMessageFragmentViewModel _cmf = new CreateMessageFragmentViewModel(new MessagingService(), new FriendlistService());
        public CreateMessageFragmentViewModel Cmf
        {
            get => _cmf;
            set
            {
                _cmf = value; RaisePropertyChanged(() => Cmf);
            }
        }

        private ProfileFragmentViewModel _pfv = new ProfileFragmentViewModel(new ProfileService());
        public ProfileFragmentViewModel Pfv
        {
            get => _pfv;
            set
            {
                _pfv = value;
                RaisePropertyChanged(() => Pfv);
            }
        }

    }
}
