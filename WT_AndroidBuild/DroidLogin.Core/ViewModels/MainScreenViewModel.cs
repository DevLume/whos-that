using Droid.Core.Services;
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

    }
}
