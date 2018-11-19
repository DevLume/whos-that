using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Droid.Core.ViewModels;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Platforms.Android.Binding.BindingContext;
using MvvmCross.Platforms.Android.Presenters.Attributes;

namespace Droid.App
{
    [MvxFragmentPresentation(typeof(StatisticsFragmentViewModel), Resource.Id.fragment_container)]
    [Register("Droid.App.StatisticsUI")]
    public class StatisticsUI : MvxFragment<StatisticsFragmentViewModel>
    {
        public StatisticsUI() { }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here

            StatisticsFragmentViewModel.OnRequestSent += StatisticsViewModel_OnGetTestStatisticsRequestSent;
        }

        private void StatisticsViewModel_OnGetTestStatisticsRequestSent(object sender, GetTestStatisticsEventArgs e)
        {
            if (e.pass)
            {
                string resp = "statistically it's fine for now!" + e.title;
                Toast.MakeText(this.Activity, resp, ToastLength.Long).Show();
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);

            return this.BindingInflate(Resource.Layout.statistics_personal_fragment, null);
        }
    }
}