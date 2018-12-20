using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Droid.Core;
using Droid.Core.ViewModels;
using MvvmCross.Platforms.Android.Views;

namespace Droid.App
{
    [Activity(Label = "Profile Builder")]
    class ProfileBuilderView : MvxActivity<ProfileBuilderViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.profileBuilder);

            ProfileBuilderViewModel.OnSubmitProfile += ProfileBuilderViewModel_OnSubmitProfile;
        }

        private void ProfileBuilderViewModel_OnSubmitProfile(object sender, SubmitProfileArgs e)
        {
            Toast.MakeText(this, "Profile submission ", ToastLength.Long);
        }
    }
}