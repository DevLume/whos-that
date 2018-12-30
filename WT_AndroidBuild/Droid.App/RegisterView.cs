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
    [Activity(Label = "Register Screen")]
    public class RegisterView : MvxActivity<RegisterViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.register);
            RegisterViewModel.OnRequestSent += RegisterViewModel_OnRequestSent;
            RegisterViewModel.OnInputError += RegisterViewModel_OnInputError;
        }

        private void RegisterViewModel_OnInputError(object sender, SendErrorArgs e)
        {
            Toast.MakeText(this, e.errorInfo, ToastLength.Long).Show();
        }

        private void RegisterViewModel_OnRequestSent(object sender, SendRegisterRequestArgs e)
        {
            Toast.MakeText(this, e.response, ToastLength.Long).Show();
            //continue registration from here
        }
    }
}