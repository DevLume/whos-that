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
    [Activity(Label = "Friend Profile")]
    public class FriendProfileView : MvxActivity<FriendProfileFragmentViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.friend_profile_view);

            FriendProfileFragmentViewModel.OnTestSolve += OnTestSolve;
            FriendProfileFragmentViewModel.OnFriendRq += OnFriendRq;
        }

        private void OnFriendRq(object sender, MessageArgs e)
        {
            Toast.MakeText(this, e.message, ToastLength.Long).Show();
        }

        private void OnTestSolve(object sender, GuessTestRequestArgs e)
        {
            if (e.authorName == "" || e.authorName == null)
            {
                Toast.MakeText(this, "Write user name first!", ToastLength.Long).Show();
            }
            else if (e.title == "" || e.title == null)
            {
                Toast.MakeText(this, "Write user test name first!", ToastLength.Long).Show();
            }
            else
            {
                Intent intent = new Intent(this, typeof(GuessTestView)).SetFlags(ActivityFlags.ReorderToFront);
                this.StartActivity(intent);
            }
        }
    }
}