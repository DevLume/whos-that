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
    public class StatisticsFragmentViewModel : MvxViewModel
    {
        private IStatisticsService _IStatisticsService;
        private Tuple<string, Stat> myStatTuple;
        public StatisticsFragmentViewModel(IStatisticsService iStat)
        {
            _IStatisticsService = iStat; 

            Task.Run(async () =>
            {
                myStatTuple = await _IStatisticsService.GetStatistics(LoginApp.loggedUserName);

                await SetStats(myStatTuple.Item2);
            }).GetAwaiter().GetResult();
            
        }

        private async Task SetStats(Stat myStat)
        {
            _pGuessCount += myStat.personalGuessCount.ToString();
            _oGuessCount += myStat.otherGuessCount.ToString();
            _pAverage += myStat.personalAverage.ToString();
            _oAverage += myStat.otherAverage.ToString();
            _bestGuesser += myStat.bestGuesser;
            _oHighestRes += myStat.otherHighestResult.ToString();
            _pHighestRes += myStat.personalHighestResult.ToString();
            await RaiseAllPropertiesChanged();
        }

        private string _pGuessCount = "Personal Guess Count: ";
        public string PGuessCount
        {
            get => _pGuessCount;
            set
            {
                PGuessCount = value;
                RaisePropertyChanged(() => PGuessCount);
            }
        }

        private string _oGuessCount = "Other Guess Count: ";
        public string OGuessCount
        {
            get => _oGuessCount;
            set
            {
                OGuessCount = value;
                RaisePropertyChanged(() => OGuessCount);
            }
        }

        private string _pAverage = "Personal Average: ";
        public string PAverage
        {
            get => _pAverage;
            set
            {
                PAverage = value;
                RaisePropertyChanged(() => PAverage);
            }
        }

        private string _oAverage = "Other Average: ";
        public string OAverage
        {
            get => _oAverage;
            set
            {
                OAverage = value;
                RaisePropertyChanged(() => OAverage);
            }
        }
        private string _bestGuesser = "Best Guesser: ";
        public string BestGuesser
        {
            get => _bestGuesser;
            set
            {
                BestGuesser = value;
                RaisePropertyChanged(() => BestGuesser);
            }
        }
        private string _pHighestRes = "Personal Highest Result: ";
        public string PHighestRes
        {
            get => _pHighestRes;
            set
            {
                PHighestRes = value;
                RaisePropertyChanged(() => PHighestRes);
            }
        }

        private string _oHighestRes = "Other Highest Result: ";
        public string OHighestRes
        {
            get => _oHighestRes;
            set
            {
                OHighestRes = value;
                RaisePropertyChanged(() => OHighestRes);
            }
        }

    }
}
