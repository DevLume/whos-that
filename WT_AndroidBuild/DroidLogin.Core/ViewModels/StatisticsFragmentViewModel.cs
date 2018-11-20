using MvvmCross.Commands;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Droid.Core.ViewModels
{
    public class StatisticsFragmentViewModel : MvxViewModel
    {
        //private ICreateTestService _ICreateTestService;

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

        public static event EventHandler<GetTestStatisticsEventArgs> OnRequestSent;

        private MvxCommand _getStatisticsCommand;
        public MvxCommand GetStatisticsCommand
        {
            get
            {
                _getStatisticsCommand = _getStatisticsCommand ?? new MvxCommand(DoCreateTestCommand);
                return _getStatisticsCommand;
            }
        }

        public void DoCreateTestCommand() //add async later
        {
            OnRequestSent?.Invoke(this, new GetTestStatisticsEventArgs(true, _title));
        }

    }

    public class GetTestStatisticsEventArgs : EventArgs
    {
        public bool pass;
        public string title;
        public GetTestStatisticsEventArgs(bool pass, string title)
        {
            this.pass = pass;
            this.title = title;
        }
    }
}
